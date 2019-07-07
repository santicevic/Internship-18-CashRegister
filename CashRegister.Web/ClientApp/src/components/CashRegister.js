import React, { Component } from "react";

export default class CashRegister extends Component {
    constructor(props){
        super(props);

        this.state={
            itemsInBasket: [
            {id: 1, name: "bread", price: 7.99},
            {id: 2, name: "onion", price: 3.99},
            {id: 3, name: "sauce", price: 12.99}]
        }
    }

    getTotalPrice = itemsInBasket => {
        let total = 0;
        
        for(let item in itemsInBasket){
            total += itemsInBasket[item].price
        }

        return total;
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
                        <p>{item.name} {item.price}</p>
                    </div>)}
                    <h2>TOTAL: {this.getTotalPrice(this.state.itemsInBasket)}</h2>
                </div>
            </div>
        )
    }
}