import React, { Component } from "react";
import { getNextTenReceipts } from "../utils"

export default class LookupReceipts extends Component{
    constructor(props){
        super(props);

        this.state = {
            receipts: [],
            loading: true
        }
    }

    componentDidMount(){
        getNextTenReceipts(0).then(receipts => {this.setState({ receipts: [...receipts], loading: false})})
    }

    loadNextTenReceipts = () => {
        getNextTenReceipts(this.state.receipts.length)
        .then(receipts => {this.setState(state => ({ receipts: [...state.receipts, ...receipts]}))});
    }

    render(){
        return (
            <div>
                <ol>
                    {this.state.receipts.map(receipt => (
                        <li key={receipt.id}>
                            <h6>Id: {receipt.id}</h6>
                            <h6>Cash register: {receipt.cashRegisterId}</h6>
                            <h6>Cashier: {receipt.cashierId}</h6>
                            <button>Load receipt details</button>
                        </li>
                    ))}
                    <button onClick={this.loadNextTenReceipts}>Load next ten</button>
                </ol>
            </div>
        )
    }
}