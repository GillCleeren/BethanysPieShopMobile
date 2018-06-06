using System;
using BethanysPieShop.API.Models;
using BethanysPieShop.API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Authenticate(string userName, string password)
        {
            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@something.com",
                    FirstName = "Gill",
                    LastName = "Cleeren",
                    UserName = userName
                }
            });
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Register(string firstName, string lastName, string email, string userName, string password)
        {
            return Ok(new AuthenticationResponse
            {
                IsAuthenticated = true,
                User = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName
                }
            });
        }
    }
}
