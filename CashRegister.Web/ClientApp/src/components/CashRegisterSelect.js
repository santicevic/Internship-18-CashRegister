import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class CashRegisterSelect extends Component {
    constructor(props){
        super(props);

        this.state = {
            cashRegisters: [{id:1},{id:2},{id:3},{id:4}],
            loading: false
        }
    }

    render () {
        return(
            <div>
                {this.state.cashRegisters.map(cashRegister => 
                <div key={cashRegister.id}>
                    <h1>Cash register number {cashRegister.id}</h1>
                    <Link to={{pathname: "/cashier-select", state: {cashRegister}}}>Choose</Link>
                </div>  
                )}
            </div>
        )
    }
}