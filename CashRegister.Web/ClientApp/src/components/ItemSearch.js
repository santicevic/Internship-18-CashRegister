import React, { Component } from "react";
import AwesomeDebouncePromise from "awesome-debounce-promise";

const searchAPI = filter => fetch("/api/items/filter/" + filter).then(response => response.json());

const searchAPIDebounced = AwesomeDebouncePromise(searchAPI, 500);

export default class ItemSearch extends Component {
    state = {
        filter: "",
        results: [],
        choosenItem: null,
        amountToAdd: 1
    }

    handleTextChange = async e => {
        this.setState({ filter: e.target.value, results: [] });
        const results = await searchAPIDebounced(e.target.value);
        this.setState({ results });
    }

    handleChooseClick = item => {
        if(this.getMaxAmountOfChoosenItem(item) <= 0){
            alert("Available amount of this item is 0");
            return;
        }

        fetch("/api/items/get-by-id/" + item.id)
        .then(response => response.json())
        .then(choosenItem => this.setState({ choosenItem }))
    }

    handleAmountChange = e => {
        this.setState({amountToAdd: e.target.value})
    }

    componentWillUnmount() {
        this.setState = () => {};
    }

    getMaxAmountOfChoosenItem = choosenItem => {
        const { itemsInBasket } = this.props;
        const matchingItemInCartList = itemsInBasket.filter(item => item.choosenItem.id === choosenItem.id);
        if(matchingItemInCartList.length > 0){
            return choosenItem.amountInStock - matchingItemInCartList[0].amount;
        }
        return choosenItem.amountInStock;
    }

    render() {
        const { choosenItem, filter, results, amountToAdd } = this.state;
        if(choosenItem !== null){
            return(
                <div>
                    <h2>Name: {choosenItem.name}</h2>
                    <span>Select amount to add: </span>
                    <input value={amountToAdd} onChange={e => this.handleAmountChange(e)} type="range" min="1" max={this.getMaxAmountOfChoosenItem(this.state.choosenItem)} />
                    <span>{amountToAdd}</span>
                    <button onClick={() => this.props.onAddItemToBasket({choosenItem, amount: parseInt(amountToAdd, 10)})}>Add</button>
                </div>
            )
        }

        return(
            <div>
                <input type="text" value={filter} placeholder="search" onChange={e => this.handleTextChange(e)} />
                {results.map(item => 
                <div key={item.id}>
                    <h3>Name: {item.name}</h3>
                    <p>Price: {item.priceWithTax} kn Amount in stock: {item.amountInStock} Barcode: {item.barcode}</p>
                    <button onClick={() => this.handleChooseClick(item)}>Choose</button>
                </div>)}
            </div>
        )
    }
}