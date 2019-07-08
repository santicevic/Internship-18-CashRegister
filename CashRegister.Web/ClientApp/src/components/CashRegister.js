import React, { Component } from "react";
import Modal from "./Modal";
import ItemSearch from "./ItemSearch";

export default class CashRegister extends Component {
    constructor(props){
        super(props);

        this.state={
            itemsInBasket: [],
            modalIsOpen: false
        }

    }
    
    componentDidMount() {
        document.addEventListener("keydown", this.handleKeyDown, false);
    }

    componentWillUnmount() {
        document.removeEventListener("keydown", this.handleKeyDown, false);
    }

    toggleModal = () => {
        this.setState(state => ({
            modalIsOpen: !state.modalIsOpen
        }));
    }

    getTotalPrice = itemsInBasket => {
        let total = 0;
        
        for(let item in itemsInBasket){
            total += itemsInBasket[item].price
        }

        return total;
    }

    handleKeyDown = event => {
        // 13 is Enter keyCode
        if(event.keyCode === 13){
            this.setState({ modalIsOpen: true });
        }
    }

    render() {
        const { cashRegister, cashier } = this.props.location.state;
        return(
            <div>
                <div>
                    <h5>Cash register: {cashRegister.id}</h5>
                    <h5>Cashier: {cashier.name}({cashier.id})</h5>
                </div>
                <div>
                    <h3>Items:</h3>
                    {this.state.itemsInBasket.map(item => 
                    <div key={item.id}>
                        <p>{item.name} {item.price} Amount: {item.amount}</p>
                    </div>)}
                    <h2>TOTAL: {this.getTotalPrice(this.state.itemsInBasket)}</h2>
                </div>
                <button onClick={this.toggleModal}>Open modal</button>
                <Modal show={this.state.modalIsOpen} onClose={this.toggleModal}>
                    <ItemSearch />
                </Modal>
            </div>
        )
    }
}