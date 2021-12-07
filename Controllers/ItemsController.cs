using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
using Catalog.ItemDtos;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")] // GET /items
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository repository;

        // Depencency Injection of IItemRepository
        public ItemsController(IItemRepository repository)
        {
            this.repository = repository;
        }

        //GET  /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
    }
}