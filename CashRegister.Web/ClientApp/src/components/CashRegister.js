import React, { Component } from "react";
import Modal from "./Modal";
import ItemAddToBasket from "./ItemAddToBasket";
import { addReceipt, addItemReceipts, getItemReceipts } from "../utils";
import { PrintTool } from "react-print-tool";
import ReceiptPrint from "./ReceiptPrint";
import { Link, Redirect } from "react-router-dom";

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

    handleCheckout = () => {
        if(this.state.itemsInBasket.length < 1){
            alert("Nothing to add!")
            return;
        }

        const { cashRegister, cashier } = this.props.location.state;
        let receipt = {
            cashRegisterId: cashRegister.id,
            cashierId: cashier.id,
            creationTime: new Date()
        }

        addReceipt(receipt)
        .then(data => {
            let itemReceiptsToAdd = []

            for(let item in this.state.itemsInBasket){
                const { choosenItem, amount } = this.state.itemsInBasket[item];
                itemReceiptsToAdd.push({
                    amount,
                    itemId: choosenItem.id,
                    receiptId: data.id,
                    priceWithTax: choosenItem.priceWithTax,
                    tax: choosenItem.tax
                })
            }
            
            addItemReceipts(itemReceiptsToAdd)
            .then(response => response.json())
            .then(itemsNotAdded => {
                if(itemsNotAdded.length > 0){
                    alert("Some items were not processed correctly, please double check the receipt!")
                }

                this.setState({
                    itemsInBasket: [],
                    modalIsOpen: false
                })

                getItemReceipts(data.id)
                .then(itemReceipts => {
                    PrintTool.printFromReactComponent(<ReceiptPrint itemReceipts={itemReceipts} />);
                }).catch(err => {
                    alert("Something went wrong, error logged to console!");
                    console.log(err);
                })
            }).catch(err => {
                alert("Something went wrong, error logged to console!");
                console.log(err);
            })
        }).catch(() => alert("Something went wrong :/"))
    }

    render() {
        const { cashRegister, cashier } = this.props.location.state;

        return(
            <div>
                <div>
                    <Link to="/">Home</Link>
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
                <button onClick={this.toggleModal}>Look for items</button>
                <Modal show={this.state.modalIsOpen} onClose={this.toggleModal}>
                    <ItemAddToBasket onAddItemToBasket = {this.handleAddItemToBasket} itemsInBasket = {this.state.itemsInBasket} />
                </Modal>
                <button onClick={this.handleCheckout}>Checkout</button>
            </div>
        )
    }
}