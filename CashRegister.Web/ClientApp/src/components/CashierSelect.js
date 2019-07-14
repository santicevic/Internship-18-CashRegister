import React, { Component } from "react";
import { Link } from "react-router-dom";
import { getAllCashiers } from "../utils"

export default class CashierSelect extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cashiers: [],
            loading: true
        }
    }

    componentDidMount() {
        getAllCashiers().then(data => {this.setState({ cashiers: data, loading: false })})
        .catch(err => {
            alert("Something went wrong, error logged to console!");
            console.log(err);
        })
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
                        <Link to={{ pathname: "/cash-register", state: { cashRegister, cashier } }}>Choose</Link>
                    </div>
                )}
            </div>
        )
    }
}