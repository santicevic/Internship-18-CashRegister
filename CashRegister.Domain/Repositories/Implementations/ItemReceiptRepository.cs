using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Domain.Repositories.Implementations
{
    public class ItemReceiptRepository : IItemReceiptRepository
    {
        public ItemReceiptRepository(CashRegisterContext context)
        {
            _context = context;
        }
        private readonly CashRegisterContext _context;

        public void AddItemReceipt(ItemReceipt itemReceiptToAdd)
        {
            _context.ItemReceipts.Add(itemReceiptToAdd);
            _context.SaveChanges();
        }

        public List<ItemReceipt> GetAllItemReceipts()
        {
            return _context.ItemReceipts.ToList();
        }

        public List<ItemReceipt> GetItemReceiptsByReceiptId(Guid id)
        {
            return _context.ItemReceipts.Where(itemReceipt => itemReceipt.ReceiptId == id).ToList();
        }
    }
}
