using CashRegister.Data.Entities;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Domain.Repositories.Implementations
{
    public class CashierRepository : ICashierRepository
    {
        public CashierRepository(CashRegisterContext context)
        {
            _context = context;
        }
        private readonly CashRegisterContext _context;

        public bool AddCashier(Cashier cashierToAdd)
        {
            var doesCashierWithSameNameExist = _context.Cashiers.Any(cashier => string.Equals(cashier.Name, cashierToAdd.Name, StringComparison.CurrentCultureIgnoreCase));

            if (doesCashierWithSameNameExist)
                return false;

            _context.Cashiers.Add(cashierToAdd);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCashier(int idOfCashierToDelete)
        {
            var cashierToDelete = _context.Cashiers.Find(idOfCashierToDelete);

            if (cashierToDelete == null)
                return false;

            _context.Cashiers.Remove(cashierToDelete);
            _context.SaveChanges();
            return true;
        }

        public bool EditCashier(Cashier editedCashier)
        {
            var doesCashierWithSameNameExist = _context.Cashiers.Any(cashier => string.Equals(cashier.Name, editedCashier.Name, StringComparison.CurrentCultureIgnoreCase));

            if (doesCashierWithSameNameExist)
                return false;

            var cashierToEdit = _context.Cashiers.Find(editedCashier.Id);

            cashierToEdit.Name = editedCashier.Name;

            _context.SaveChanges();
            return true;
        }

        public List<Cashier> GetAllCashiers()
        {
            return _context.Cashiers.ToList();
        }

        public Cashier GetCashierById(int id)
        {
            return _context.Cashiers.Find(id);
        }
    }
}
