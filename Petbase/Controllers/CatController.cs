using Microsoft.AspNetCore.Mvc;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System.Collections.Generic;

namespace Petbase.Controllers
{
    [Route("api/[controller]")]
    public class CatController : Controller
    {
        private readonly IRepository repository;
        private readonly IPetFinderApiService service;

        public CatController(IRepository repository, IPetFinderApiService service)
        {
            this.repository = repository;
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Cats> Get()
        {
            return repository.GetAll<Cats>();
        }

        [HttpGet("petfinder")]
        public dynamic GetPets()
        {
            return service.GetPets(null);
        }
    }
}
