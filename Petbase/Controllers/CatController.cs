using DataService.Interfaces;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Petbase.Controllers
{
    [Route("api/[controller]")]
    public class CatController : Controller
    {
        private readonly IRepository repository;

        public CatController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Cats> Get()
        {
            return this.repository.GetAll<Cats>();
        }
    }
}
