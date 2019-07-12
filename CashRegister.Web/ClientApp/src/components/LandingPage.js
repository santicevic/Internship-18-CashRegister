import React, { Component } from "react";
import { Link } from "react-router-dom";
import Modal from "./Modal";
import AddItem from "./AddItem";
import LookupItems from "./LookupItems";
import LookupReceipts from "./LookupReceipts";

export default class LandingPage extends Component{
    constructor(props){
        super(props);

        this.state={
            addItemModalIsOpen: false,
            lookupItemModalIsOpen: false,
            lookupReceiptModalIsOpen: false
        }
    }

    toggleAddItemModal = () => {
        this.setState(state => ({ addItemModalIsOpen: !state.addItemModalIsOpen }));
    }

    toggleLookupItemModal = () => {
        this.setState(state => ({ lookupItemModalIsOpen: !state.lookupItemModalIsOpen }));
    }

    toggleLookupReceiptModal = () => {
        this.setState(state => ({ lookupReceiptModalIsOpen: !state.lookupReceiptModalIsOpen}))
    }

    render() {
        const { lookupItemModalIsOpen, lookupReceiptModalIsOpen, addItemModalIsOpen } = this.state;

        return(
            <div>
                <Link to={{pathname: "/cash-register-select"}}>Pick cash register and employee</Link>
                <div>
                    <button onClick={this.toggleAddItemModal}>Add item</button>
                    <button onClick={this.toggleLookupItemModal}>Lookup items</button>
                    <button onClick={this.toggleLookupReceiptModal}>Lookup  receipts</button>
                </div>
                <Modal show={lookupItemModalIsOpen} onClose={this.toggleLookupItemModal}>
                    <LookupItems />
                </Modal>
                <Modal show={addItemModalIsOpen} onClose={this.toggleAddItemModal}>
                    <AddItem onItemSubmit={this.toggleAddItemModal} />
                </Modal>
                <Modal show={lookupReceiptModalIsOpen} onClose={this.toggleLookupReceiptModal}>
                    <LookupReceipts />
                </Modal>
            </div>
        )
    }
}