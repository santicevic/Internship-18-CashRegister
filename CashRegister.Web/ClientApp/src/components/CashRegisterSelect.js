import React, { Component } from "react";
import { Link } from "react-router-dom";
import { getAllCashRegisters } from "../utils";

export default class CashRegisterSelect extends Component {
    constructor(props){
        super(props);

        this.state = {
            cashRegisters: [],
            loading: true
        }
    }

    componentDidMount() {
        getAllCashRegisters().then(data => {this.setState({ cashRegisters: data, loading: false })})
    }

    render () {
        if(this.state.loading){
            return <h1>Loading...</h1>
        }
        
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