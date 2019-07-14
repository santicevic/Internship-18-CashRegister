import React, { Component } from "react";
import { getNextTenReceipts, getReceiptsByDate } from "../utils";
import Modal from "./Modal";
import ReceiptDetails from "./ReceiptDetails";

export default class LookupReceipts extends Component {
    constructor(props) {
        super(props);

        this.state = {
            receipts: [],
            loading: true,
            receipt: null,
            dateInputField: ""
        }
    }

    componentDidMount() {
        getNextTenReceipts(0).then(receipts => { this.setState({ receipts: [...receipts], loading: false }) })
        .catch(err => {
            alert("Something went wrong, error logged to console!");
            console.log(err);
        })
    }

    loadNextTenReceipts = () => {
        this.setState({ loading: true });
        getNextTenReceipts(this.state.receipts.length)
            .then(receipts => { this.setState(state => ({ receipts: [...state.receipts, ...receipts], loading: false })) })
            .catch(err => {
                alert("Something went wrong, error logged to console!");
                console.log(err);
            });
    }

    closeReceiptDetails = () => {
        this.setState({ receipt: null });
    }

    handleReceiptDetailsClick = receipt => {
        this.setState({ receipt });
    }

    handleInputChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    getDateInMiliseconds = dateString => {
        const date = new Date(dateString);
        const day = date.getDate();
        const month = date.getMonth();
        const year = date.getFullYear();

        return Date.UTC(year, month, day);
    }

    filterReceiptsByDate = () => {
        if(this.state.dateInputField === ""){
            return;
        }

        getReceiptsByDate(this.getDateInMiliseconds(this.state.dateInputField))
            .then(receipts => this.setState({ receipts }))
            .catch(err => {
                alert("Something went wrong, error logged to console!");
                console.log(err);
            })
    }

    handleClearFilter = () => {
        this.setState({ dateInputField: "",  receipts: [] });
        this.loadNextTenReceipts();
    }

    render() {
        return (
            <div>
                <input type="date" name="dateInputField" onChange={e => this.handleInputChange(e)} value={this.state.dateInputField} />
                <button onClick={this.filterReceiptsByDate}>Filter</button>
                <div>
                    <ol>
                    {this.state.receipts.map(receipt => (
                        <li key={receipt.id}>
                            <h6>Id: {receipt.id}</h6>
                            <h6>Cash register: {receipt.cashRegisterId}</h6>
                            <h6>Cashier: {receipt.cashierId}</h6>
                            <button onClick={() => this.handleReceiptDetailsClick(receipt)}>
                                Load receipt details
                                    </button>
                        </li>
                    ))}
                    </ol>
                    {
                        this.state.loading ? <h3>Loading...</h3> :
                        this.state.dateInputField === "" ?
                        <button onClick={this.loadNextTenReceipts}>Load next ten</button> :
                        <button onClick={this.handleClearFilter}>Clear filter</button>
                    }
                </div>
                <Modal show={this.state.receipt !== null} onClose={this.closeReceiptDetails}>
                    <ReceiptDetails receipt={this.state.receipt} />
                </Modal>
            </div>
        )
    }
}