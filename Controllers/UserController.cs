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

namespace Kiosk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
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
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
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
            catch (Exception)
            {
                return StatusCode(500, "Enter some error message");
            }

        }

        // ADD USER
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserVM uvm)
        {
            var user = new Users 
            { 
                Name = uvm.Name,
                Surname = uvm.Surname,
                EmailAddress = uvm.EmailAddress,
                PhysicalAddress = uvm.PhysicalAddress,
                Password = uvm.Password,
                SignupDate = uvm.SignupDate,
                UserRole = uvm.UserRole,

            };

            try
            {
                _repository.Add(user);
                await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                // fix error message
                return BadRequest("Invalid Transaction");
            }

            return Ok(user);
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
                existingUser.EmailAddress = uvm.EmailAddress;
                existingUser.EmailAddress = uvm.EmailAddress;
                existingUser.PhysicalAddress = uvm.PhysicalAddress;
                existingUser.Password = uvm.Password;
                existingUser.UserRole = uvm.UserRole;

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingUser);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return BadRequest("Your request is invalid");
        }
        
    }
}
