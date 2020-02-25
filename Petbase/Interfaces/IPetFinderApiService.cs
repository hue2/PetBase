using Petbase.Models;
using System.Threading.Tasks;

namespace Petbase.Interfaces
{
    public interface IPetFinderApiService
    {
        Task<AnimalResult> GetPets(AnimalFilter filters);
    }
}
