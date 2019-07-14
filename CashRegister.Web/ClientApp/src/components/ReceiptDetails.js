import React, { Component } from "react";
import { getItemReceipts } from "../utils";

export default class ReceiptDetails extends Component {
    constructor(props) {
        super(props);

        this.state = {
            itemReceipts: [],
            loading: true
        }
    }

    componentWillMount() {
        getItemReceipts(this.props.receipt.id)
            .then(data => this.setState({ itemReceipts: [...data], loading: false }))
            .catch(err => {
                alert("Something went wrong, error logged to console!");
                console.log(err);
            });
    }

    getPriceInfo = itemReceipts => {
        const fivePercentTaxItems = itemReceipts.filter(itemReceipt => itemReceipt.tax === 5);
        const twentyFivePercentTaxItems = itemReceipts.filter(itemReceipt => itemReceipt.tax === 25);

        let totalFivePercentTax = 0;
        let totalTwentyFivePercentTax = 0;
        let totalWithTax = 0;

        for (let itemReceipt in fivePercentTaxItems) {
            const { amount, priceWithTax } = fivePercentTaxItems[itemReceipt]

            totalWithTax += priceWithTax * amount;
            totalFivePercentTax += amount * (priceWithTax * 0.05);
        }

        for (let itemReceipt in twentyFivePercentTaxItems) {
            const { amount, priceWithTax } = twentyFivePercentTaxItems[itemReceipt]

            totalWithTax += priceWithTax * amount;
            totalTwentyFivePercentTax += amount * (priceWithTax * 0.25);
        }

        const totalWithoutTax = totalWithTax - totalFivePercentTax - totalTwentyFivePercentTax;

        return {
            totalFivePercentTax,
            totalTwentyFivePercentTax,
            totalWithTax,
            totalWithoutTax
        }
    }

    render() {
        const { receipt } = this.props;
        const { itemReceipts, loading } = this.state;
        const priceInfo = this.getPriceInfo(itemReceipts);
        if (loading) {
            return <h3>Loading...</h3>
        }

        return (
            <div>
                <h3>Time and date: {receipt.creationTime}</h3>
                <h3>Receipt id: {receipt.id}</h3>
                <h3>Cashier id: {receipt.cashierId}</h3>
                <ol>
                    {itemReceipts.map(itemReceipt => (
                        <li key={itemReceipt.receiptId + itemReceipt.itemId}>Name {itemReceipt.item.name} Amount {itemReceipt.amount} Price {itemReceipt.priceWithTax}</li>
                    ))}
                </ol>
                <h3>Price without tax: {priceInfo.totalWithoutTax}</h3>
                <h3>25% tax: {priceInfo.totalTwentyFivePercentTax}</h3>
                <h3>5% tax: {priceInfo.totalFivePercentTax}</h3>
                <h3>Total price: {priceInfo.totalWithTax}</h3>
            </div>
        )
    }
}