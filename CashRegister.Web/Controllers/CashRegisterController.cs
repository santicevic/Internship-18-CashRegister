using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashRegister.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Web.Controllers
{
    [Route("api/cash-registers")]
    [ApiController]
    public class CashRegisterController : ControllerBase
    {
        public CashRegisterController(ICashRegisterRepository cashRegisterRepository)
        {
            _cashRegisterRepository = cashRegisterRepository;
        }
        private readonly ICashRegisterRepository _cashRegisterRepository;

        [HttpGet("all")]
        public IActionResult GetAllCashRegisters()
        {
            return Ok(_cashRegisterRepository.GetAllCashRegisters());
        }
    }
}