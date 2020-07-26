using Microsoft.AspNetCore.Mvc;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using Petbase.DataService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Petbase.Controllers
{
    [Route("api/[controller]")]
    public class PetFinderController : Controller
    {
        private readonly IPetFinderApiService service;
        private readonly IRepository repository;

        public PetFinderController(IPetFinderApiService service, IRepository repository)
        {
            this.service = service;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<AnimalResult> GetPets(string breed, int zipcode, int distance)
        {
            return await service.GetPets(new AnimalFilter() { Breed = breed, Location = zipcode, Distance = distance });
        }

        [HttpGet("names")]
        public IEnumerable<string> GetBreeds()
        {
            return repository.GetNames();
        }
    }
}
