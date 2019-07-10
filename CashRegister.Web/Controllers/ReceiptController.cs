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
    [Route("api/receipts")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        public ReceiptController(IReceiptRepository receiptRepository, IItemReceiptRepository itemReceiptRepository)
        {
            _receiptRepository = receiptRepository;
            _itemReceiptRepository = itemReceiptRepository;
        }
        private readonly IReceiptRepository _receiptRepository;
        private readonly IItemReceiptRepository _itemReceiptRepository;

        [HttpGet("all")]
        public IActionResult GetAllReceipts()
        {
            return Ok(_receiptRepository.GetAllReceipts());
        }

        [HttpPost("add-receipt")]
        public IActionResult AddReceipt(Receipt receiptToAdd)
        {
           var addedReceipt = _receiptRepository.AddReceipt(receiptToAdd);

           return Ok(addedReceipt);
        }

        [HttpPost("add-item-receipt")]
        public IActionResult AddItemReceipt(List<ItemReceipt> itemReceiptsToAdd)
        {
            foreach(var itemReceipt in itemReceiptsToAdd)
            {
                _itemReceiptRepository.AddItemReceipt(itemReceipt);
            }

            return Ok();
        }

        [HttpGet("get-receipt-by-id/{id}")]
        public IActionResult GetAirportById(Guid id)
        {
            var receipt = _receiptRepository.GetReceiptById(id);
            var itemReceipts = _itemReceiptRepository.GetItemReceiptsByReceiptId(id);

            if (receipt != null)
            {
                return Ok(new { receipt, itemReceipts });
            }
            return NotFound();
        }
    }
}