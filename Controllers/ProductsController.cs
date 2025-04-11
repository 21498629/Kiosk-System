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
using Kiosk.Models.User;
using Kiosk.View_Models.User;
using Microsoft.CodeAnalysis;

namespace Kiosk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository _repository;

        public ProductsController(AppDbContext appDbContext, IRepository repository)
        {
            _appDbContext = appDbContext;
            _repository = repository;
        }

        // GET ALL PRODUCTS
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var results = await _repository.GetAllProductsAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET PRODUCT BY ID
        [HttpGet]
        [Route("GetProduct/{ProductID}")]
        public async Task<ActionResult> GetUProduct(int ProductID)
        {
            try
            {
                var product = await _repository.GetProductAsync(ProductID);
                if (product == null) return NotFound("Product does not exist.");
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // ADD PRODUCT
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductVM pvm)
        {
            var product = new Products
            {
                Name = pvm.Name,
                Description = pvm.Description,
                Price = pvm.Price,
                Image = pvm.Image,
                Quantity = pvm.Quantity,
                IsActive = pvm.IsActive,
                CategoryID = pvm.CategoryID,
                SupplierID = pvm.SupplierID,
            };

            try
            {
                _repository.Add(product);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

            return Ok(product);
        }

        // EDIT PRODUCT
        [HttpPut]
        [Route("EditProduct/{ProductID}")]
        public async Task<ActionResult<ProductVM>> EditProduct(int ProductID, ProductVM pvm)
        {
            try
            {
                var existingProduct = await _repository.GetProductAsync(ProductID);

                if (existingProduct == null) return NotFound($"The product does not exist");

                existingProduct.Name = pvm.Name;
                existingProduct.Description = pvm.Description;
                existingProduct.Price = pvm.Price;
                existingProduct.Image = pvm.Image;
                existingProduct.Quantity = pvm.Quantity;
                existingProduct.IsActive = pvm.IsActive;
                existingProduct.CategoryID = pvm.CategoryID;
                existingProduct.SupplierID = pvm.SupplierID;
            

            if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingProduct);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Your request is invalid");
        }

        // DELETE PRODUCT
        [HttpDelete]
        [Route("DeleteProduct/{ProductID}")]
        public async Task<IActionResult> DeleteProduct(int ProductID)
        {
            try
            {
                var existingProduct = await _repository.GetProductAsync(ProductID);

                if (existingProduct == null) return NotFound($"The product does not exist");

                _repository.Delete(existingProduct);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(existingProduct);
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
