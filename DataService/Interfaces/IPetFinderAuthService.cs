using System.Threading.Tasks;

namespace Petbase.DataService.Interfaces
{
    public interface IPetFinderAuthService
    {
        Task<string> GetAccessToken();
        string GetTokenFromCache();
    }
}
