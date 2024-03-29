﻿using CashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Domain.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        Receipt AddReceipt(Receipt receiptToAdd);
        Receipt GetReceiptById(Guid id);
        List<Receipt> GetNextTenReceipts(int refPoint);
        List<Receipt> GetReceiptByDate(DateTime date);
    }
}
