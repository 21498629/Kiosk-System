using Kiosk.Models;
using Kiosk.Models.User;
using Kiosk.View_Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace Kiosk.Controllers
{
    //[Authorize(Roles = "Superuser")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;
        private readonly AppDbContext _appDbContext;

        public UserRoleController(RoleManager<IdentityRole> roleManager, UserManager<Users> userManager, AppDbContext appDbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        // GET ALL USER ROLES
        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = _roleManager.Roles.Select(r => new RoleVM
                {
                    RoleID = r.Id,
                    Name = r.Name
                }).ToList();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET USER ROLE BY ID
        [HttpGet]
        [Route("GetRole/{RoleID}")]
        public async Task<ActionResult> GetRole(string RoleID)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(RoleID);
                if (role == null) return NotFound("User role does not exist.");
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // ADD USER ROLE
        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] RoleVM rvm)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var role = new IdentityRole(rvm.Name);
            var result = await _roleManager.CreateAsync(role);
            
            if (result.Succeeded)
                return CreatedAtAction(nameof(GetAllRoles), new { id = role.Id }, new RoleVM { RoleID = role.Id, Name = role.Name });

            return BadRequest(result.Errors);
        }

        // EDIT USER ROLE
        [HttpPut]
        [Route("EditRole/{RoleID}")]
        public async Task<ActionResult> EditRole(string RoleID, [FromBody] RoleVM rvm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var role = await _roleManager.FindByIdAsync(RoleID);
            if (role == null)
                return NotFound();

            role.Name = rvm.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Errors);
        }

        // DELETE USER ROLE
        [HttpDelete]
        [Route("DeleteUserRole/{RoleID}")]
        public async Task<IActionResult> DeleteRole(string RoleID)
        {
            var existingRole = await _roleManager.FindByIdAsync(RoleID);
            if (existingRole == null)
                return NotFound();

            var result = await _roleManager.DeleteAsync(existingRole);
            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Errors);
        }
    }
}
