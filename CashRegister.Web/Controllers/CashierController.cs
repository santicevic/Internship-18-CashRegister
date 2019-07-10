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

        [HttpPost("add")]
        public IActionResult AddCashier(Cashier cashierToAdd)
        {
            var wasAddSuccessful = _cashierRepository.AddCashier(cashierToAdd);
            if (wasAddSuccessful)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpPost("edit")]
        public IActionResult EditCashier(Cashier editedCashier)
        {
            var wasEditSuccessful = _cashierRepository.EditCashier(editedCashier);
            if (wasEditSuccessful)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCashier(int id)
        {
            var wasDeleteSuccessful = _cashierRepository.DeleteCashier(id);
            if (wasDeleteSuccessful)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetCashierId(int id)
        {
            var cashier = _cashierRepository.GetCashierById(id);
            if (cashier != null)
            {
                return Ok(cashier);
            }
            return NotFound();
        }
    }
}