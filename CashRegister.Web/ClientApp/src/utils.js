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

export const getItemReceipts = receiptId =>
    fetch("/api/receipts/get-item-receipts-by-receipt-id/" + receiptId)
    .then(response => response.json())

export const addItem = item => 
    fetch("/api/items/add", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(item)
    })

export const getAllItems = () =>
    fetch("/api/items/all")
    .then(response => response.json())

export const getItemById = itemId =>
    fetch("/api/items/get-by-id/" + itemId)
    .then(response => response.json())

export const editItem = item => 
    fetch("/api/items/edit", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(item)
    })

export const restockItem = item => 
    fetch("/api/items/restock", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(item)
    })

export const getAllCashRegisters = () =>
    fetch("/api/cash-registers/all")
    .then(response => response.json())

export const getNextTenReceipts = refPoint =>
    fetch("/api/receipts/get-next-ten-receipts/" + refPoint)
    .then(response => response.json())

export const getNextTenItems = refPoint =>
    fetch("/api/items/get-next-ten-items/" + refPoint)
    .then(response => response.json())

export const getReceiptsByDate = dateinMiliseconds => 
fetch("/api/receipts/get-receipt-by-date/"+dateinMiliseconds).then(response => response.json())