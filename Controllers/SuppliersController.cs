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
    public class SuppliersController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository _repository;

        public SuppliersController(AppDbContext appDbContext, IRepository repository)
        {
            _appDbContext = appDbContext;
            _repository = repository;
        }

        // GET ALL SUPPLIERS 
        [HttpGet]
        [Route("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var results = await _repository.GetAllSuppliersAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET SUPPLIER BY ID
        [HttpGet]
        [Route("GetSupplier/{SupplierID}")]
        public async Task<ActionResult> GetSuppliers(int SupplierID)
        {
            try
            {
                var supplier = await _repository.GetSupplierRepresentativeAsync(SupplierID);
                if (supplier == null) return NotFound("Supplier does not exist.");
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // ADD SUPPLIER 
        [HttpPost]
        [Route("AddSupplier")]
        public async Task<IActionResult> AddSupplier(SuppliersVM svm)
        {
            var supplier = new Suppliers
            {
                Name = svm.Name,
                Email_Address = svm.Email_Address,
                PhoneNumber = svm.PhoneNumber,
                Physical_Address = svm.Physical_Address,
                RepresentativeID = svm.RepresentativeID,
            };

            try
            {
                _repository.Add(supplier);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

            return Ok(supplier);
        }

        // EDIT SUPPLIER REPRESENTATIVE
        [HttpPut]
        [Route("EditSupplier/{SupplierID}")]
        public async Task<ActionResult<SuppliersVM>> EditSupplier(int SupplierID, SuppliersVM svm)
        {
            try
            {
                var existingSupplier = await _repository.GetSupplierAsync(SupplierID);

                if (existingSupplier == null) return NotFound($"The supplier does not exist");

                existingSupplier.Name = svm.Name;
                existingSupplier.Email_Address = svm.Email_Address;
                existingSupplier.PhoneNumber = svm.PhoneNumber;
                existingSupplier.Physical_Address = svm.Physical_Address;
                existingSupplier.RepresentativeID = svm.RepresentativeID;


                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingSupplier);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Your request is invalid");
        }

        // DELETE SUPPLIER 
        [HttpDelete]
        [Route("DeleteSupplier/{SupplierID}")]
        public async Task<IActionResult> DeleteSupplier(int SupplierID)
        {
            try
            {
                var existingSupplier = await _repository.GetSupplierAsync(SupplierID);

                if (existingSupplier == null) return NotFound($"The supplier does not exist");

                _repository.Delete(existingSupplier);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingSupplier);
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
