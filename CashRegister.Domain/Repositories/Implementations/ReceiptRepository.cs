using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Domain.Repositories.Implementations
{
    public class ReceiptRepository : IReceiptRepository
    {
        public ReceiptRepository(CashRegisterContext context)
        {
            _context = context;
        }
        private readonly CashRegisterContext _context;

        public Receipt AddReceipt(Receipt receiptToAdd)
        {
            var addedReceipt = _context.Receipts.Add(receiptToAdd).Entity;
            _context.SaveChanges();

            return addedReceipt;
        }

        public List<Receipt> GetAllReceipts()
        {
            return _context.Receipts.ToList();
        }

        public Receipt GetReceiptById(Guid id)
        {
            return _context.Receipts.Find(id);
        }
    }
}
