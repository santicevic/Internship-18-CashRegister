using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Data.Entities.Models
{
    public class ItemReceipt
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
        public int Amount { get; set; }
    }
}
