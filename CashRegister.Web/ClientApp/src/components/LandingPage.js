import React, { Component } from "react";
import { Link } from "react-router-dom";
import Modal from "./Modal";
import AddItem from "./AddItem";
import LookupItems from "./LookupItems";
import LookupReceipts from "./LookupReceipts";

export default class LandingPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            addItemModalIsOpen: false,
            lookupDisplay: null
        }
    }

    toggleAddItemModal = () => {
        this.setState(state => ({ addItemModalIsOpen: !state.addItemModalIsOpen }));
    }

    handleChangeDisplay = display => {
        this.setState({ lookupDisplay: display })
    }

    render() {
        const { addItemModalIsOpen, lookupDisplay } = this.state;
        let display = <div></div>

        if (lookupDisplay === "items") {
            display = <LookupItems />
        }
        if (lookupDisplay === "receipts") {
            display = <LookupReceipts />
        }

        return (
            <div>
                <Link to={{ pathname: "/cash-register-select" }}>Pick cash register and employee</Link>
                <div>
                    <button onClick={this.toggleAddItemModal}>Add item</button>
                    <button onClick={() => this.handleChangeDisplay("items")}>Lookup items</button>
                    <button onClick={() => this.handleChangeDisplay("receipts")}>Lookup  receipts</button>
                </div>
                {display}
                <Modal show={addItemModalIsOpen} onClose={this.toggleAddItemModal}>
                    <AddItem onItemSubmit={this.toggleAddItemModal} />
                </Modal>
            </div>
        )
    }
}