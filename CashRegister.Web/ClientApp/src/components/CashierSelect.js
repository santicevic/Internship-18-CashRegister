import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class CashierSelect extends Component {
    constructor(props){
        super(props);

        this.state={
            cashiers:[{id:1, name:"Iva"}, {id:2, name:"Luka"}, {id:3, name:"Marko"}],
            loading: true,
            nameInputValue: ""
        }
    }

    handleInputChange = e => {
        this.setState({nameInputValue: e.target.value});
    }

    handleSubmit = () => {
        console.log("tu");
        fetch("api/cashiers/add", {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify({name:this.state.nameInputValue})
        }).then(response => response.json()).then(result => console.log(result)).catch(error => console.log(error))
    }

    render() {
        const { cashRegister } = this.props.location.state;

        return(
            <div>
                {this.state.cashiers.map(cashier => 
                    <div key={cashier.id}>
                        <h3>Cashier:</h3>
                        <h1>{cashier.name}</h1>
                        <h5>{cashier.id}</h5>
                        <Link to={{pathname: "/cash-register", state: {cashRegister, cashier}}}>Choose</Link>
                    </div>
                )}
                <h3>Add new cashier:</h3>
                <label>Name: </label>
                <input type="text" value={this.state.nameInputValue} onChange={this.handleInputChange} />
                <button onClick={() => this.handleSumbit}>Submit</button>
            </div>
        )
    }
}