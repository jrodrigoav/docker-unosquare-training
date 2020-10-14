using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Common.Models;

namespace IdentityAPI.Services
{
    public class ActiveDirectoryClientService : IActiveDirectoryClientService
    {
        private readonly HttpClient _client;

        public ActiveDirectoryClientService(HttpClient client)
        {
            _client=client;
        }
        public async Task<ADUser> GetADUserAsync(string samAccountName)
        {
            return await _client.GetFromJsonAsync<ADUser>($"api/user/{samAccountName}");
        }
    }
}