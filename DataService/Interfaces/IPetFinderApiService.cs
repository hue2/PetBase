using Petbase.DataService.Models;
using System.Threading.Tasks;

namespace Petbase.DataService.Interfaces
{
    public interface IPetFinderApiService
    {
        Task<AnimalResult> GetPets(AnimalFilter filters);
    }
}
