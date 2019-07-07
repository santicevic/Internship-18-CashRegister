using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Data.Entities.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int AmountInStock { get; set; }
        public float Tax { get; set; }
        public float PriceWithTax { get; set; }
        public string Name { get; set; }
        public int Barcode { get; set; }
        public ICollection<ItemReceipt> ItemReceipts { get; set; }
    }
}
