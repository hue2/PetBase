using Microsoft.AspNetCore.Mvc;
using Petbase.DataService.Interfaces;
using Petbase.DataService.Models;
using System.Threading.Tasks;

namespace Petbase.Controllers
{
    [Route("api/[controller]")]
    public class PetFinderController : Controller
    {
        private readonly IPetFinderApiService service;

        public PetFinderController(IPetFinderApiService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<AnimalResult> GetPets(string breed, int zipcode, int distance)
        {
            return await service.GetPets(new AnimalFilter() { Breed = breed, Location = zipcode, Distance = distance });
        }
    }
}
