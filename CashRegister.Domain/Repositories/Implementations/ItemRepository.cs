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

        public bool EditItem(Item editedItem)
        {
            var itemToEdit = _context.Items.Find(editedItem.Id);

            if (itemToEdit == null)
                return false;

            itemToEdit.PriceWithTax = editedItem.PriceWithTax;
            itemToEdit.Tax = editedItem.Tax;
            itemToEdit.AmountInStock = editedItem.AmountInStock;

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
