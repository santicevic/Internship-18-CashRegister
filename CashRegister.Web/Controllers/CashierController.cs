using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashRegister.Data.Entities.Models;
using CashRegister.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Web.Controllers
{
    [Route("api/cashiers")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        public CashierController(ICashierRepository cashierRepository)
        {
            _cashierRepository = cashierRepository;
        }
        private readonly ICashierRepository _cashierRepository;
        
        [HttpGet("all")]
        public IActionResult GetAllCashiers()
        {
            return Ok(_cashierRepository.GetAllCashiers());
        }
    }
}