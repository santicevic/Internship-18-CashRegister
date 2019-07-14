import React, { Component } from "react";
import { restockItem } from "../utils";

export default class RestockItem extends Component {
    constructor(props) {
        super(props);

        this.state = {
            amountToRestock: 1
        }
    }

    handleChange = e => {
        const targetValue = parseInt(e.target.value, 10);
        this.setState({ amountToRestock: targetValue })
    }

    handleRestockClick = () => {
        if (this.state.amountToRestock < 1) {
            alert("The amount has to be 1 or more!");
            return;
        }

        const { item } = this.props;
        item.amountInStock += this.state.amountToRestock;
        restockItem(item).then(response => {
            if (response.status !== 200) {
                alert("Something went wrong");
            } else {
                this.props.onItemRestocked();
            }
        }).catch(err => {
            alert("Something went wrong, error logged to console!");
            console.log(err);
        })
    }

    render() {
        const { name, amountInStock, priceWithTax } = this.props.item
        return (
            <div>
                <label>Name: {name}</label><br />
                <label>Price: {priceWithTax}</label><br />
                <label>Amount in stock: {amountInStock}</label><br />
                <label>Enter amount to restock: </label>
                <input type="number" value={this.state.amountToRestock} placeholder="Amount" name="amount" onChange={this.handleChange} /><br />
                <button onClick={this.handleRestockClick}>Restock</button>
            </div>
        )
    }
}