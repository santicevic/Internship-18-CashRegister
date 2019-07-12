using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Domain.Repositories.Implementations
{
    public class ItemRepository : IItemRepository
    {
        public ItemRepository(CashRegisterContext context)
        {
            _context = context;
        }
        private readonly CashRegisterContext _context;

        public bool AddItem(Item itemToAdd)
        {
            var doesItemWithSameNameExist = _context.Items.Any(item => string.Equals(item.Name, itemToAdd.Name, StringComparison.CurrentCultureIgnoreCase));
            var doesItemWithSameBarcodeExist = _context.Items.Any(item => string.Equals(item.Barcode, itemToAdd.Barcode, StringComparison.CurrentCultureIgnoreCase));
            var isBarcodeOnlyDigits = Int32.TryParse(itemToAdd.Barcode, out int num);

            if (doesItemWithSameNameExist || doesItemWithSameBarcodeExist || !isBarcodeOnlyDigits)
                return false;

            _context.Items.Add(itemToAdd);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteItem(int idOfItemToDelete)
        {
            var itemToDelete = _context.Items.Find(idOfItemToDelete);

            if (itemToDelete == null)
                return false;

            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();
            return true;
        }

        public bool RestockItem(Item restockedItem)
        {
            var itemToRestock = _context.Items.Find(restockedItem.Id);

            if(itemToRestock == null || itemToRestock.AmountInStock >= restockedItem.AmountInStock)
            {
                return false;
            }

            itemToRestock.AmountInStock = restockedItem.AmountInStock;
            _context.SaveChanges();
            return true;
        }

        public bool ValidateAndReduceAmountInStock(ItemReceipt itemReceiptToValidate)
        {
            var itemToReduceStockAmountTo = _context.Items.Find(itemReceiptToValidate.ItemId);
            if(itemToReduceStockAmountTo == null)
            {
                return false;
            }

            if(itemToReduceStockAmountTo.AmountInStock < itemReceiptToValidate.Amount || itemToReduceStockAmountTo.PriceWithTax != itemReceiptToValidate.PriceWithTax)
            {
                return false;
            }

            itemToReduceStockAmountTo.AmountInStock -= itemReceiptToValidate.Amount;
            _context.SaveChanges();
            return true;
        }

        public bool EditItem(Item editedItem)
        {
            var itemToEdit = _context.Items.Find(editedItem.Id);

            if (itemToEdit == null || editedItem.Tax != 5 && editedItem.Tax != 25)
            {
                return false;
            }

            itemToEdit.PriceWithTax = editedItem.PriceWithTax;
            itemToEdit.Tax = editedItem.Tax;
            itemToEdit.Barcode = editedItem.Barcode;

            _context.SaveChanges();
            return true;
        }

        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.Find(id);
        }

        public List<Item> GetItemsFilterByNameAndBarcode(string filter)
        {
            var filteredByName = _context.Items.Where(item => item.Name.Contains(filter));
            var filteredByBarcode = _context.Items.Where(item => item.Barcode.Contains(filter));
 
            return filteredByName.Union(filteredByBarcode).ToList();
        }
    }
}
