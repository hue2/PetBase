using DataService.Interfaces;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
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