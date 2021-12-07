using System;
using System.Collections.Generic;
using Catalog.Entities;
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
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }

        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult <Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }
            
            return item;
            
        }
    }
}