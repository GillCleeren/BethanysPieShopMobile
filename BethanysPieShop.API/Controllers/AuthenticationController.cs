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
        //public IActionResult Authenticate(string userName, string password)
        public IActionResult Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            Console.WriteLine($"authenticationRequest = {authenticationRequest}");
            
            var userName = authenticationRequest.UserName;

            Console.WriteLine($"userName = {authenticationRequest.UserName}");
            Console.WriteLine($"password = {authenticationRequest.Password}");
            if (userName.ToLower() == "joe")
            {
                return Ok(new AuthenticationResponse
                {
                    IsAuthenticated = false,
                    User = new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = userName,
                        FirstName = "Dummy",
                        LastName = "Dummy",
                        Email = "test@something.com"
                    }
                });
            }
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
