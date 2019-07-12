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
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        private readonly IItemRepository _itemRepository;

        [HttpGet("all")]
        public IActionResult GetAllItems()
        {
            return Ok(_itemRepository.GetAllItems());
        }

        [HttpPost("add")]
        public IActionResult AddItem(Item itemToAdd)
        {
            var wasAddSuccessful = _itemRepository.AddItem(itemToAdd);
            if (wasAddSuccessful)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpPost("restock")]
        public IActionResult RestockItem(Item restockedItem)
        {
            var wasRestockSuccessful = _itemRepository.RestockItem(restockedItem);

            if (wasRestockSuccessful)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpPost("edit")]
        public IActionResult EditItem(Item editedItem)
        {
            var wasEditSuccessful = _itemRepository.EditItem(editedItem);
            if (wasEditSuccessful)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var wasDeleteSuccessful = _itemRepository.DeleteItem(id);
            if (wasDeleteSuccessful)
            {
                return Ok();
            }
            return Forbid();
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _itemRepository.GetItemById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpGet("filter/{filter}")]
        public IActionResult GetFiltered(string filter)
        {
            return Ok(_itemRepository.GetItemsFilterByNameAndBarcode(filter));
        }
    }
}