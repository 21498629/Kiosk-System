using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Kiosk.Models;
using Kiosk.Models.User;
using Kiosk.View_Models.User;
using NuGet.Protocol.Core.Types;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Data.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Kiosk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;  
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Users> _signInManager;
        private readonly AppDbContext _appDbContext;

        public UserController(IRepository repository, UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService, SignInManager<Users> signInManager, AppDbContext appDbContext)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
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
                    PasswordHash = uvm.Password,
                };

                var createdUser = await _userManager.CreateAsync(user, uvm.Password);

                if (createdUser.Succeeded)
                { 
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new UserVM
                            {
                            Name = user.Name,
                            Token = _tokenService.CreateToken(user)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                
                else
                {
                    return BadRequest(createdUser.Errors);
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

                //var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == lvm.EmailAddress.ToLower());

                var user = await _userManager.FindByEmailAsync(lvm.EmailAddress.ToLower());

                if ( user == null)
                {
                    return Unauthorized("Invalid Email Address");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, lvm.Password, false);

                if (!result.Succeeded)
                {
                    return Unauthorized("Email Address not found and/or Password incorrect.");
                }

                return Ok(new
                {
                    user.UserName,
                    Token = _tokenService.CreateToken(user),
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "SuperUser")]
        // GET ALL USERS
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
                if (users == null) return NotFound("User does not exist.");
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // ADD USER
        //[Authorize]
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
                    PasswordHash = uvm.Password,
                };

                var createdUser = await _userManager.CreateAsync(user, uvm.Password);

                if (createdUser.Succeeded)
                {
                    if (!string.IsNullOrEmpty(uvm.RoleName))
                    {
                        var roleExists = await _roleManager.RoleExistsAsync(uvm.RoleName);
                        if (!roleExists)
                            return BadRequest("Specified role does not exists");

                        var addToRoleResult = await _userManager.AddToRoleAsync(user, uvm.RoleName);
                        if (!addToRoleResult.Succeeded)
                            return BadRequest(addToRoleResult.Errors);
                    }
                    return Ok(
                        new UserVM
                        {
                            Name = user.Name,
                            Token = _tokenService.CreateToken(user)
                        }
                    );
                }

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

                if (existingUser == null) return NotFound($"The user does not exist");

                existingUser.Name = uvm.Name;
                existingUser.Surname = uvm.Surname;
                existingUser.Email = uvm.EmailAddress;
                existingUser.PhysicalAddress = uvm.PhysicalAddress;
                existingUser.PasswordHash = uvm.Password;
                //existingUser.UserRoleID = uvm.UserRoleID;

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

                if (existingUser == null) return NotFound($"The user does not exist");

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
