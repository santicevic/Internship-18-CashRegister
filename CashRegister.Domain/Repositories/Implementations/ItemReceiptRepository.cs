using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public bool AddItemReceipt(ItemReceipt itemReceiptToAdd)
        {
            if(_context.Items.Any(item => item.Id == itemReceiptToAdd.ItemId) &&
            _context.Receipts.Any(receipt => receipt.Id == itemReceiptToAdd.ReceiptId))
            {
                _context.ItemReceipts.Add(itemReceiptToAdd);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ItemReceipt> GetItemReceiptsByReceiptId(Guid id)
        {
            return _context.ItemReceipts
                .Include(itemReceipt => itemReceipt.Item)
                .Include(itemReceipt => itemReceipt.Receipt)
                .Where(itemReceipt => itemReceipt.ReceiptId == id).ToList();
        }
    }
}
