using CashRegister.Data.Entities;
using CashRegister.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Domain.Repositories.Implementations
{
    public class CashRegisterRepository : ICashRegisterRepository
    {
        public CashRegisterRepository(CashRegisterContext context)
        {
            _context = context;
        }
        private readonly CashRegisterContext _context;

        public List<Data.Entities.Models.CashRegister> GetAllCashRegisters()
        {
            return _context.CashRegisters.ToList();
        }
    }
}
