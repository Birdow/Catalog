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
        private readonly InMemItemRepository repository;

        public ItemsController()
        {
            repository = new InMemItemRepository();
        }
        
        //GET  /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }
    }
}