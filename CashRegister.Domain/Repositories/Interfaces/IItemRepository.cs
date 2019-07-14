using CashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Domain.Repositories.Interfaces
{
    public interface IItemRepository
    {
        bool AddItem(Item itemToAdd);
        bool RestockItem(Item restockedItem);
        bool ValidateAndReduceAmountInStock(ItemReceipt itemReceiptToValidate);
        bool EditItem(Item editedItem);
        Item GetItemById(int id);
        List<Item> GetItemsFilterByNameAndBarcode(string filter);
        List<Item> GetNextTenItems(int refPoint);
    }
}
