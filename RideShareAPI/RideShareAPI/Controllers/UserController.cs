using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideShareAPI.Data;
using RideShareAPI.Models;

namespace RideShareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly RideShareAPIDbContext _dbContext;

        public UserController(RideShareAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _dbContext.User.ToListAsync());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(RegisterUser userRegisteration)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(userRegisteration);
            //}


            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = userRegisteration.FirstName,
                LastName = userRegisteration.LastName,
                Phone = userRegisteration.Phone,
                Email = userRegisteration.Email,
                Password = userRegisteration.Password,
                ConfirmPassword = userRegisteration.ConfirmPassword
            };

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
