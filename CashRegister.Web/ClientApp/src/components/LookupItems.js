import React, { Component } from "react";
import { getNextTenItems, getItemById } from "../utils";
import EditItem from "./EditItem";
import RestockItem from "./RestockItem";
import Modal from "./Modal";

export default class LookupItems extends Component {
    constructor(props) {
        super(props);

        this.state = {
            items: [],
            loading: true,
            itemToEdit: null,
            itemToRestock: null
        }
    }

    componentDidMount() {
        getNextTenItems(0).then(items => { this.setState({ items: [...items], loading: false }) })
    }

    loadNextTenItems = () => {
        this.setState({ loading: true })
        getNextTenItems(this.state.items.length)
            .then(items => { this.setState(state => ({ items: [...state.items, ...items], loading: false })) });
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

    render() {
        const { items, itemToEdit, itemToRestock, loading } = this.state;

        return (
            <div>
                <div>
                        <ol>
                        {
                            items.map(item =>
                            <li key={item.id}>
                                Name: {item.name} Amount: {item.amountInStock} Price: {item.priceWithTax}<br />
                                <button onClick={() => this.handleEditClick(item.id)}>Edit</button>
                                <button onClick={() => this.handleRestockClick(item.id)}>Restock</button>
                            </ li>
                            )
                        }
                        </ol>
                        {
                            loading ? <h3>Loading...</h3> :
                            <button onClick={this.loadNextTenItems}>Load next ten</button>
                        }              
                </div>
                <Modal show={itemToRestock !== null} onClose={this.handleItemRestocked}>
                    <RestockItem item={itemToRestock} onItemRestocked={this.handleItemRestocked} />
                </Modal>
                <Modal show={itemToEdit !== null} onClose={this.handleItemEdited}>
                    <EditItem item={itemToEdit} onItemEdited={this.handleItemEdited} />
                </Modal>
            </div>
        )
    }
}