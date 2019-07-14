import React, { Component } from "react";
import { editItem } from "../utils";

export default class ItemEdit extends Component{
    constructor(props){
        super(props);
        const { item } = this.props;

        this.state={
            price: item.priceWithTax,
            tax: item.tax + "%",
            barcode: item.barcode
        }
    }

    handleChange = e => {
        const targetName = e.target.name;
        const targetValue = e.target.value;

        this.setState({ [targetName]: targetValue })
    }

    handleSubmit = () => {
        const { price, tax, barcode } = this.state;
        let { item, onItemEdited } = this.props;

        if(barcode.match(/^[0-9]+$/) === null){
            alert("Barcode can contain only digits");
            return;
        }

        if(tax !== "5%" && tax !== "25%"){
            alert("Tax is not correct");
            return;
        }

        item.priceWithTax = price;
        item.tax = parseFloat(tax);
        item.barcode = barcode;

        editItem(item).then(response => {
            if(response.status !== 200){
                alert("Something went wrong");
            }else{
                onItemEdited();
            }
        }).catch(err => {
            alert("Something went wrong, error logged to console!");
            console.log(err);
        })
    }

    render(){
        const { price, tax, barcode } = this.state;
        const { item } = this.props;

        return(
            <div>
                <label>Name: {item.name}</label><br />
                <label>Amount in stock: {item.amountInStock}</label><br />
                <label>Barcode</label>
                <input type="text" value={barcode} placeholder="Barcode" name="barcode" onChange={this.handleChange} /><br />
                <label>Tax</label><br />
                <input type="radio" value="5%" name="tax" checked={tax === "5%"} onChange={this.handleChange} /> 5%<br />
                <input type="radio" value="25%" name="tax" checked={tax === "25%"} onChange={this.handleChange} /> 25%<br /><br />
                <label>Price with tax</label>
                <input type="number" value={price} step="0.01" min="0.01" placeholder="Price with tax" name="price" onChange={this.handleChange} /><br />
                <button onClick={this.handleSubmit}>Submit</button>
            </div>
        )
    }
}