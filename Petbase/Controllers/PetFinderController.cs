﻿using Microsoft.AspNetCore.Mvc;
using Petbase.Interfaces;
using Petbase.Models;
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
        public async Task<AnimalResult> GetPets(string breed, string zipcode)
        {
            return await service.GetPets(new AnimalFilter() { Breed = breed, ZipCode = zipcode });
        }
    }
}
