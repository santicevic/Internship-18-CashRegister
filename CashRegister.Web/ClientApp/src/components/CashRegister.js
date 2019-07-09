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
            const { choosenItem, amount } = itemsInBasket[item];
            total += amount * choosenItem.priceWithTax;
        }

        return total;
    }

    handleKeyDown = event => {
        // 13 is Enter keyCode
        if(event.keyCode === 13){
            this.setState({ modalIsOpen: true });
        }
    }
    
    handleAddItemToBasket = itemToAdd => {
        const matchingItemInList = this.state.itemsInBasket.filter(item => item.choosenItem.id === itemToAdd.choosenItem.id)
        if(matchingItemInList.length > 0){
            const newTotalAmount = itemToAdd.amount + matchingItemInList[0].amount;
            const basketWithoutItemToAdd = this.state.itemsInBasket.filter(item => item.choosenItem.id !== itemToAdd.choosenItem.id)
            
            this.setState({
                itemsInBasket: [...basketWithoutItemToAdd, { choosenItem: itemToAdd.choosenItem, amount: newTotalAmount }],
                modalIsOpen: false
            })
            return;
        }
        this.setState(state => ({
            itemsInBasket: [...state.itemsInBasket, itemToAdd],
            modalIsOpen: false
        }))
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
                    <div key={item.choosenItem.id}>
                        <p>{item.choosenItem.name} {item.choosenItem.priceWithTax} Amount: {item.amount}</p>
                    </div>)}
                    <h2>TOTAL: {this.getTotalPrice(this.state.itemsInBasket)}</h2>
                </div>
                <button onClick={this.toggleModal}>Open modal</button>
                <Modal show={this.state.modalIsOpen} onClose={this.toggleModal}>
                    <ItemSearch onAddItemToBasket = {this.handleAddItemToBasket} itemsInBasket = {this.state.itemsInBasket} />
                </Modal>
            </div>
        )
    }
}