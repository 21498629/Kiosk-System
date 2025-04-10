using Kiosk.Models;
using Kiosk.Models.User;
using Kiosk.View_Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserRoleController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllUserRoles")]
        public async Task<IActionResult> GetAllUserRoles()
        {
            try
            {
                var results = await _repository.GetAllUserRolesAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

        // GET USER ROLE BY ID
        [HttpGet]
        [Route("GetUserRole/{RoleID}")]
        public async Task<ActionResult> GetUserRole(int RoleID)
        {
            try
            {
                var roles = await _repository.GetUserRoleAsync(RoleID);
                if (roles == null) return NotFound("User role does not exist.");
                return Ok(roles);
            }
            catch (Exception)
            {
                return StatusCode(500, "Enter some error message");
            }

        }

        // ADD USER ROLE
        [HttpPost]
        [Route("AddUserRole")]
        public async Task<IActionResult> AddUserRole(UserRoleVM rvm)
        {
            var role = new UserRole
            {
                RoleID = rvm.RoleID,
                Name = rvm.Name,
                Description = rvm.Description
            };

            try
            {
                _repository.Add(role);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

            return Ok(role);
        }

        // EDIT USER ROLE
        [HttpPut]
        [Route("EditUserRole/{RoleID}")]
        public async Task<ActionResult<UserRoleVM>> EditUserRole(int RoleID, UserRoleVM rvm)
        {
            try
            {
                var existingRole = await _repository.GetUserRoleAsync(RoleID);

                // fix error message
                if (existingRole == null) return NotFound($"The user role does not exist");

                existingRole.Name = rvm.Name;
                existingRole.Description = rvm.Description;

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingRole);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error. Please contact support.");
            }
            return BadRequest("Your request is invalid");
        }

        // DELETE USER ROLE
        [HttpDelete]
        [Route("DeleteUserRole/{RoleID}")]
        public async Task<IActionResult> DeleteUserRole(int RoleID)
        {
            try
            {
                var existingRole = await _repository.GetUserRoleAsync(RoleID);

                // fix error message
                if (existingRole == null) return NotFound($"The user role does not exist");

                _repository.Delete(existingRole);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingRole);
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
