export const getAllCashiers = () => 
    fetch("/api/cashiers/all")
    .then(response =>  response.json());

export const addReceipt = receipt => 
    fetch("/api/receipts/add-receipt", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(receipt)
    }).then(response => response.json());

export const addItemReceipts = itemReceipt => 
    fetch("/api/receipts/add-item-receipt", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(itemReceipt)
    })