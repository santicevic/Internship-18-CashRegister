using CashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Domain.Repositories.Interfaces
{
    public interface IItemReceiptRepository
    {
        void AddItemReceipt(ItemReceipt itemReceiptToAdd);
        List<ItemReceipt> GetItemReceiptsByReceiptId(Guid id);
    }
}
