import React, { Component } from "react";
import { addItem } from "../utils";

export default class AddItem extends Component{
    constructor(props){
        super(props);

        this.state = {
            name: "",
            amount: 1,
            barcode: "",
            tax: "25%",
            price: 0
        }
    }

    handleChange = e => {
        const targetName = e.target.name;
        const targetValue = e.target.value;

        this.setState({ [targetName]: targetValue })
    }

    handleNewItemSubmit = () => {
        const { name, amount, barcode, tax, price } = this.state;
        if(amount < 1){
            alert("The amount has to be 1 or more!");
            return;
        }

        if(name === ""){
            alert("Name is not optional!");
            return;
        }
        
        if(barcode.match(/^[0-9]+$/) === null){
            alert("Barcode can contain only digits");
            return;
        }

        if(tax !== "5%" && tax !== "25%"){
            alert("Tax is not correct");
            return;
        }

        const itemToAdd = {
            amountInStock: amount,
            tax: parseFloat(tax),
            priceWithTax: price,
            name,
            barcode
        }

        addItem(itemToAdd)
        .then(response => {
            if(response.status !== 200){
                alert("Something went wrong!")
            } else{
                this.props.onItemSubmit();
            }
        }).catch(err => {
            alert("Something went wrong, error logged to console!");
            console.log(err);
        });
    }

    render() {
        const { name, amount, barcode, tax, price } = this.state;

        return(
        <div>
            <label>Name</label>
            <input type="text" value={name} placeholder="Name" name="name" onChange={this.handleChange} /><br />
            <label>Amount</label>
            <input type="number" value={amount} placeholder="Amount" name="amount" onChange={this.handleChange} /><br />
            <label>Barcode</label>
            <input type="text" value={barcode} placeholder="Barcode" name="barcode" onChange={this.handleChange} /><br />
            <label>Tax</label><br />
            <input type="radio" value="5%" name="tax" checked={tax === "5%"} onChange={this.handleChange} /> 5%<br />
            <input type="radio" value="25%" name="tax" checked={tax === "25%"} onChange={this.handleChange} /> 25%<br /><br />
            <label>Price with tax</label>
            <input type="number" value={price} step="0.01" min="0.01" placeholder="Price with tax" name="price" onChange={this.handleChange} /><br />
            <button onClick={this.handleNewItemSubmit}>Submit</button>
        </div>
        )
    }
}