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

    handleChooseClick = id => {
        fetch("/api/items/get-by-id/" + id)
        .then(response => response.json())
        .then(choosenItem => this.setState({ choosenItem }))
    }

    handleAmountChange = e => {
        this.setState({amountToAdd: e.target.value})
    }

    componentWillUnmount() {
        this.setState = () => {};
    }

    render() {
        const { choosenItem, filter, results, amountToAdd } = this.state;
        console.log(this.props)
        if(choosenItem !== null){
            return(
                <div>
                    <h2>Name: {choosenItem.name}</h2>
                    <span>Select amount to add: </span>
                    <input value={amountToAdd} onChange={e => this.handleAmountChange(e)} type="range" min="1" max={choosenItem.amountInStock} />
                    <span>{amountToAdd}</span>
                    <button>Add</button>
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
                    <button onClick={() => this.handleChooseClick(item.id)}>Choose</button>
                </div>)}
            </div>
        )
    }
}