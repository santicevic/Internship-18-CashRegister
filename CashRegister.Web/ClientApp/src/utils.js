export const getAllCashiers = () => fetch("/api/cashiers/all").then(response =>  response.json())