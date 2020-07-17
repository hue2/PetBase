using Microsoft.AspNetCore.Mvc;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System.Collections.Generic;

namespace Petbase.Controllers
{
    [Route("api/[controller]")]
    public class DogController : Controller
    {
        private readonly IRepository repository;

        public DogController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Dogs> Get()
        {
            return this.repository.GetAll<Dogs>();
        }
    }
}