﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ReceiptController(IReceiptRepository receiptRepository, IItemReceiptRepository itemReceiptRepository, IItemRepository itemRepository)
        {
            _receiptRepository = receiptRepository;
            _itemReceiptRepository = itemReceiptRepository;
            _itemRepository = itemRepository;
        }
        private readonly IReceiptRepository _receiptRepository;
        private readonly IItemReceiptRepository _itemReceiptRepository;
        private readonly IItemRepository _itemRepository;

        [HttpPost("add-receipt")]
        public IActionResult AddReceipt(Receipt receiptToAdd)
        {
           receiptToAdd.CreationTime = DateTime.Now;
           var addedReceipt = _receiptRepository.AddReceipt(receiptToAdd);
           if(addedReceipt != null)
           {
                return Ok(addedReceipt);
           }
           return Forbid();
        }

        [HttpPost("add-item-receipt")]
        public IActionResult AddItemReceipt(List<ItemReceipt> itemReceiptsToAdd)
        {
            var itemReceiptsNotAdded = new List<ItemReceipt>();

            foreach (var itemReceipt in itemReceiptsToAdd)
            {
                var wasReduceSuccessful = _itemRepository.ValidateAndReduceAmountInStock(itemReceipt);

                if (wasReduceSuccessful)
                {
                    _itemReceiptRepository.AddItemReceipt(itemReceipt);
                }
                else
                {
                    itemReceiptsNotAdded.Add(itemReceipt);
                }
            }
            
            return Ok(itemReceiptsNotAdded);
        }

        [HttpGet("get-item-receipts-by-receipt-id/{id}")]
        public IActionResult GetItemReceiptsById(Guid id)
        {
            return Ok(_itemReceiptRepository.GetItemReceiptsByReceiptId(id));
        }

        [HttpGet("get-next-ten-receipts/{refPoint}")]
        public IActionResult GetNextTenReceipts(int refPoint)
        {
            return Ok(_receiptRepository.GetNextTenReceipts(refPoint));
        }

        [HttpGet("get-receipt-by-date/{dateInMiliseconds}")]
        public IActionResult GetReceiptByDate(long dateInMiliseconds)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(dateInMiliseconds);
            return Ok(_receiptRepository.GetReceiptByDate(date));
        }
    }
}