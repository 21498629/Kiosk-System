using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Kiosk.Models;
using Kiosk.View_Models;
using Kiosk.Models.User;
using Kiosk.View_Models.User;
using NuGet.Protocol.Core.Types;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Data.Entity;

namespace Kiosk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly UserManager<Users> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Users> _signInManager;
        private readonly AppDbContext _appDbContext;

        public UserController(IRepository repository, UserManager<Users> userManager, ITokenService tokenService, SignInManager<Users> signInManager, AppDbContext appDbContext)
        {
            _repository = repository;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }

        // REGISTER
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserVM uvm)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (string.IsNullOrEmpty(uvm.Password))
                    return BadRequest(new { message = "Password is required" });

                var user = new Users
                {
                    Name = uvm.Name,
                    Surname = uvm.Surname,
                    Email = uvm.EmailAddress,
                    UserName = uvm.UserName,
                    PhysicalAddress = uvm.PhysicalAddress,
                    PhoneNumber = uvm.PhoneNumber,
                    SignupDate = uvm.SignupDate,
                    UserRoleID = uvm.UserRoleID,
                    PasswordHash = uvm.Password,
                };
                 
                var createdUser = await _userManager.CreateAsync(user, uvm.Password);

                var role = await _appDbContext.UserRole.FindAsync(uvm.UserRoleID);
                if (role == null)
                    return BadRequest("Invalid role selected.");


                if (createdUser.Succeeded)
                    return Ok("User Created");
                
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        // LOGIN
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM lvm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == lvm.EmailAddress.ToLower());

                if ( user == null)
                {
                    return Unauthorized("Invalid Email Address");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, lvm.Password, false);

                if (!result.Succeeded)
                {
                    return Unauthorized("Email Address not found and/or Password incorrect.");
                }

                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var results = await _repository.GetAllUsersAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET USER BY ID
        [HttpGet]
        [Route("GetUser/{UserID}")]
        public async Task<ActionResult> GetUser(int UserID)
        {
            try
            {
                var users = await _repository.GetUserAsync(UserID);
                if (users == null) return NotFound("User role does not exist.");
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // ADD USER
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserVM uvm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (string.IsNullOrEmpty(uvm.Password))
                    return BadRequest(new { message = "Password is required" });

                var user = new Users
                {
                    Name = uvm.Name,
                    Surname = uvm.Surname,
                    Email = uvm.EmailAddress,
                    UserName = uvm.UserName,
                    PhysicalAddress = uvm.PhysicalAddress,
                    PhoneNumber = uvm.PhoneNumber,
                    SignupDate = uvm.SignupDate,
                    UserRoleID = uvm.UserRoleID,
                    PasswordHash = uvm.Password,
                };

                var createdUser = await _userManager.CreateAsync(user, uvm.Password);

                var role = await _appDbContext.UserRole.FindAsync(uvm.UserRoleID);
                if (role == null)
                    return BadRequest("Invalid role selected.");


                if (createdUser.Succeeded)
                    return Ok("User Created");

                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }

        }

        // EDIT USER
        [HttpPut]
        [Route("EditUser/{UserID}")]
        public async Task<ActionResult<UserVM>> EditUser(int UserID, UserVM uvm)
        {
            try
            {
                var existingUser = await _repository.GetUserAsync(UserID);

                // fix error message
                if (existingUser == null) return NotFound($"The user role does not exist");

                existingUser.Name = uvm.Name;
                existingUser.Surname = uvm.Surname;
                existingUser.Email = uvm.EmailAddress;
                existingUser.PhysicalAddress = uvm.PhysicalAddress;
                existingUser.PasswordHash = uvm.Password;
                existingUser.UserRoleID = uvm.UserRoleID;

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingUser);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Your request is invalid");
        }

        // DELETE USER
        [HttpDelete]
        [Route("DeleteUser/{UserID}")]
        public async Task<IActionResult> DeleteUser(int UserID)
        {
            try
            {
                var existingUser = await _repository.GetUserAsync(UserID);

                // fix error message
                if (existingUser == null) return NotFound($"The user role does not exist");

                _repository.Delete(existingUser);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingUser);
                }
                ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Your request is invalid");
        }
        
    }
}
