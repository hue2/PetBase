using Microsoft.AspNetCore.Mvc;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System.Collections.Generic;

namespace Petbase.Controllers
{
    [Route("api/[controller]")]
    public class RabbitController : Controller
    {
        private readonly IRepository repository;

        public RabbitController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Rabbits> Get()
        {
            return this.repository.GetAll<Rabbits>();
        }
    }
}