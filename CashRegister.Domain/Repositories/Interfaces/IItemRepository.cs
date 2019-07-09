using CashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Domain.Repositories.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetAllItems();
        bool AddItem(Item itemToAdd);
        bool EditItem(Item editedItem);
        bool DeleteItem(int idOfItemToDelete);
        Item GetItemById(int id);
        List<Item> GetItemsFilterByNameAndBarcode(string filter);
    }
}
