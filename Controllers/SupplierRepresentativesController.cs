using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kiosk.Models;
using Kiosk.Models.Inventory;
using Kiosk.View_Models.Inventory;

namespace Kiosk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierRepresentativesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository _repository;

        public SupplierRepresentativesController(AppDbContext appDbContext, IRepository repository)
        {
            _appDbContext = appDbContext;
            _repository = repository;
        }

        // GET ALL SUPPLIER REPRESENTATIVES
        [HttpGet]
        [Route("GetAllSupplierRepresentatives")]
        public async Task<IActionResult> GetAllSupplierRepresentatives()
        {
            try
            {
                var results = await _repository.GetAllSupplierRepresentativesAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET SUPPLIER REPRESENTATIVE BY ID
        [HttpGet]
        [Route("GetSupplierRepresentative/{RepresentativeID}")]
        public async Task<ActionResult> GetSupplierRepresentatives(int RepresentativeID)
        {
            try
            {
                var representative = await _repository.GetSupplierRepresentativeAsync(RepresentativeID);
                if (representative == null) return NotFound("Supplier Representative does not exist.");
                return Ok(representative);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // ADD SUPPLIER REPRESENTATIVE
        [HttpPost]
        [Route("AddSupplierRepresentative")]
        public async Task<IActionResult> AddSupplierRepresentative(SupplierRepresentativesVM rvm)
        {
            var representative = new SupplierRepresentatives
            {
                Name = rvm.Name,
                Surname = rvm.Surname,
                EmailAddress = rvm.EmailAddress,
                PhoneNumber = rvm.PhoneNumber,
            };

            try
            {
                _repository.Add(representative);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

            return Ok(representative);
        }

        // EDIT SUPPLIER REPRESENTATIVE
        [HttpPut]
        [Route("EditSupplierRepresentative/{RepresentativeID}")]
        public async Task<ActionResult<SupplierRepresentativesVM>> EditSupplierRepresentative(int RepresentativeID, SupplierRepresentativesVM rvm)
        {
            try
            {
                var existingRepresentative = await _repository.GetSupplierRepresentativeAsync(RepresentativeID);

                if (existingRepresentative == null) return NotFound($"The supplier representative does not exist");

                existingRepresentative.Name = rvm.Name;
                existingRepresentative.Surname = rvm.Surname;
                existingRepresentative.EmailAddress = rvm.EmailAddress;
                existingRepresentative.PhoneNumber = rvm.PhoneNumber;


                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingRepresentative);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Your request is invalid");
        }

        // DELETE SUPPLIER REPRESENTATIVE
        [HttpDelete]
        [Route("DeleteSupplierRepresentative/{RepresentativeID}")]
        public async Task<IActionResult> DeleteSupplierRepresentative(int RepresentativeID)
        {
            try
            {
                var existingRepresentative = await _repository.GetSupplierRepresentativeAsync(RepresentativeID);

                if (existingRepresentative == null) return NotFound($"The supplier representative does not exist");

                _repository.Delete(existingRepresentative);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingRepresentative);
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
