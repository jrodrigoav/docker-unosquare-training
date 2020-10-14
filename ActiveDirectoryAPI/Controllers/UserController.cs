using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActiveDirectoryAPI.Controllers
{
    [ApiController,Route("api/user")]
    public class UserController:ControllerBase
    {
        private readonly List<ADUser> _adUsers;

        public UserController()
        {
            _adUsers=new List<ADUser>{
                new ADUser{SAMAccountName="admin@example.com",Name="Admin"},
                new ADUser{SAMAccountName="dbaadmin@example.com",Name="DB Admin"},
                new ADUser{SAMAccountName="sysadmin@example.com",Name="Sysadmin"},
                new ADUser{SAMAccountName="netadmin@example.com",Name="Network Admin"}
            };
        }

        [HttpGet("{samAccountName}")]
        public IActionResult GetUser([EmailAddress]string samAccountName)
        {
            samAccountName =samAccountName.ToLowerInvariant();
            var result= _adUsers.FirstOrDefault(i => i.SAMAccountName == samAccountName);
            if(result is ADUser) return Ok(result);
            return NotFound();
        }
    }
}