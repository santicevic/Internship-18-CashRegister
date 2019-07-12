using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Domain.Repositories.Interfaces
{
    public interface ICashRegisterRepository
    {
        List<Data.Entities.Models.CashRegister> GetAllCashRegisters();
    }
}
