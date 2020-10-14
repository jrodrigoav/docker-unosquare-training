using System.Threading.Tasks;
using Common.Models;

namespace IdentityAPI.Services
{
    public interface IActiveDirectoryClientService
    {
        Task<ADUser> GetADUserAsync(string samAccountName);
    }
}