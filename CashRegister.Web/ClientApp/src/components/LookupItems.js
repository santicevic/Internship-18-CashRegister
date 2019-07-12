import React, { Component } from "react";
import { getAllItems, getItemById } from "../utils";
import EditItem from "./EditItem";
import RestockItem from "./RestockItem";

export default class LookupItems extends Component{
    constructor(props){
        super(props);

        this.state = {
            items: [],
            loading: true,
            itemToEdit: null,
            itemToRestock: null
        }
    }

    componentDidMount(){
        getAllItems().then(items => {this.setState({ items: [...items], loading: false})})
    }

    handleEditClick = itemId => {
        getItemById(itemId)
        .then(item => {
            this.setState({ itemToEdit: item });
        })
    }

    handleItemEdited = () => {
        this.setState({ itemToEdit: null });
    }

    handleRestockClick = itemId => {
        getItemById(itemId)
        .then(item => {
            this.setState({ itemToRestock: item });
        })
    }

    handleItemRestocked = () => {
        this.setState({ itemToRestock: null });
    }

    render(){
        const { items, itemToEdit, itemToRestock } = this.state;
        
        if(itemToEdit !== null){
            return(
                <EditItem item={itemToEdit} onItemEdited={this.handleItemEdited} />
            )
        }

        if(itemToRestock !== null){
            return(
                <RestockItem item={itemToRestock} onItemRestocked={this.handleItemRestocked} />
            )
        }
        
        return(
            <div>
                <h3>Items:</h3>
                <ol>
                    {items.map(item => 
                    <li key={item.id}>
                        Name: {item.name} Amount: {item.amountInStock} Price: {item.priceWithTax}<br />
                        <button onClick={() => this.handleEditClick(item.id)}>Edit</button>
                        <button onClick={() => this.handleRestockClick(item.id)}>Restock</button>
                    </li>)}
                </ol>
            </div>
        )
    }
}