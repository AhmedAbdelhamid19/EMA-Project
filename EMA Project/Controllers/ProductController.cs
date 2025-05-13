using EMA_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("Add")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            product.Id = DbRepository.Products.Count + 1;

            DbRepository.Products.Add(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }


        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpGet("GetAll")]
        public IActionResult GetProducts()
        {
            return Ok(DbRepository.Products.Select(p => new { p.Id, p.Name }));
        }



        [HttpGet("Restaurants/{id}")]
        public IActionResult GetRestaurantsOfProduct(int id)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            return Ok(product.Restaurants);
        }
    }
}
