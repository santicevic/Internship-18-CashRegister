import React, { Component } from "react";
import { Link } from "react-router-dom";
import { getAllCashiers } from "../utils"

export default class CashierSelect extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cashiers: [],
            loading: true,
            nameInputValue: ""
        }
    }

    componentDidMount() {
        getAllCashiers.then(data => {
                this.setState({ cashiers: data, loading: false })
            })
    }

    handleInputChange = e => {
        this.setState({ nameInputValue: e.target.value });
    }

    handleSubmit = () => {
        fetch("/api/cashiers/add", {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ name: this.state.nameInputValue })
        }).then(() => {
            fetch("/api/cashiers/all")
                .then(response => {
                    return response.json()
                })
                .then(data => {
                    this.setState({ cashiers: data, loading: false })
                })
        }).catch(() => alert("Something went wrong :/"))
    }

    handleDelete = id => {
        fetch(`/api/cashiers/delete/${id}`, {
            method: "DELETE",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            }
        }).then(() => {
            fetch("/api/cashiers/all")
                .then(response => {
                    return response.json()
                })
                .then(data => {
                    this.setState({ cashiers: data, loading: false })
                })
        }).catch(() => alert("Something went wrong :/"))
    }

    render() {
        const { cashRegister } = this.props.location.state;
        if (this.state.loading) {
            return <h3>Loading...</h3>
        }
        return (
            <div>
                {this.state.cashiers.map(cashier =>
                    <div key={cashier.id}>
                        <h3>Cashier:</h3>
                        <h1>{cashier.name}</h1>
                        <h5>{cashier.id}</h5>
                        <button onClick={(() => this.handleDelete(cashier.id))}>Delete</button>
                        <Link to={{ pathname: "/cash-register", state: { cashRegister, cashier } }}>Choose</Link>
                    </div>
                )}
                <h3>Add new cashier:</h3>
                <label>Name: </label>
                <input type="text" value={this.state.nameInputValue} onChange={this.handleInputChange} />
                <button onClick={this.handleSubmit}>Submit</button>
            </div>
        )
    }
}