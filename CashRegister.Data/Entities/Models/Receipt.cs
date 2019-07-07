using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CashRegister.Data.Entities.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int CashRegisterId { get; set; }
        public CashRegister CashRegister { get; set; }
        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }
        public ICollection<ItemReceipt> ItemReceipts { get; set; }
    }
}
