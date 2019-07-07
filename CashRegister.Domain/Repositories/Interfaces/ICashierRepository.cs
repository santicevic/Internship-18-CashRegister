using CashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Domain.Repositories.Interfaces
{
    public interface ICashierRepository
    {
        List<Cashier> GetAllCashiers();
        bool AddCashier(Cashier cashierToAdd);
        bool EditCashier(Cashier editedCashier);
        bool DeleteCashier(int idOfCashierToDelete);
        Cashier GetCashierById(int id);
    }
}
