using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using IdentityAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers
{
    [ApiController, Route("api/identity")]
    public class IdentityController : ControllerBase
    {
        private readonly List<IdentityUser> _identities;

        public IdentityController()
        {
            _identities = new List<IdentityUser>{
                new IdentityUser{Id =1 ,Username="uno"},
                new IdentityUser{Id =2 ,Username="dos"},
                new IdentityUser{Id =3 ,Username="tres"},
                new IdentityUser{Id =4 ,Username="cuatro"},
            };
        }

        [HttpGet("{id}")]
        public IActionResult GetIdentity(int id)
        {
            var result = _identities.FirstOrDefault(i => i.Id == id);
            if (result is IdentityUser) return Ok(result);

            return NotFound();
        }

        [HttpGet("ad/{samAccountName}")]
        public async Task<IActionResult> GetADUser([EmailAddress]string samAccountName,[FromServices]IActiveDirectoryClientService activeDirectoryClient)
        {
            var result = await activeDirectoryClient.GetADUserAsync(samAccountName);
            if (result is ADUser) return Ok(result);

            return NotFound();
        }
    }
}