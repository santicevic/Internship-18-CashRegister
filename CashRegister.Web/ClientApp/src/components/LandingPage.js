import React, { Component } from "react";
import { Link } from "react-router-dom";
import Modal from "./Modal";

export default class LandingPage extends Component{
    constructor(props){
        super(props);

        this.state={
            addItemModalIsOpen: false,
            lookupItemModalIsOpen: false
        }
    }

    toggleAddItemModal = () => {
        this.setState(state => ({ addItemModalIsOpen: !state.addItemModalIsOpen }));
    }

    toggleLookupItemModal = () => {
        this.setState(state => ({ lookupItemModalIsOpen: !state.lookupItemModalIsOpen }));
    }

    render() {
        const { lookupItemModalIsOpen, addItemModalIsOpen } = this.state;

        return(
            <div>
                <Link to={{pathname: "/cash-register-select"}}>Pick cash register and employee</Link>
                <div>
                    <button onClick={this.toggleAddItemModal}>Add item</button>
                    <h1>NABAVA STIGLA, EDIT ITEM</h1>
                    <h1>POPIS RACUNA</h1>
                </div>
                <Modal show={lookupItemModalIsOpen} onClose={this.toggleLookupModal}></Modal>
                <Modal show={addItemModalIsOpen} onClose={this.toggleAddItemModal}>

                </Modal>
            </div>
        )
    }
}