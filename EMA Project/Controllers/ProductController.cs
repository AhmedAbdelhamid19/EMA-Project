using EMA_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DbRepository dbRepository = new DbRepository();

        [HttpPost("Add")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            product.Id = DbRepository.Products.Count + 1;

            DbRepository.Products.Add(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }




        [HttpGet("GetProduct/{id:int}")]
        public IActionResult GetProduct(int id)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }




        [HttpGet("GetProductByName/{name:regex(^[[a-zA-Z0-9\\s]]+$)}")]
        public IActionResult GetProduct(string name)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Name == name);

            if (product == null)
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




        [HttpGet("Restaurants/{id:int}")]
        public IActionResult GetRestaurantsOfProduct(int id)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            return Ok(product.Restaurants);
        }


        [HttpGet("RestaurantsWithDistance/{id:int}/{latitude}/{longitude}")]
        public IActionResult GetRestaurantsOfProductWithDistance(int id, double latitude, double longitude)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            var result = product.Restaurants
                .Select(r => new
                {
                    Name = r.Name,
                    Distance = RestaurantController.GetDistanceInKm(latitude, longitude, r.latitude, r.longtude)
                }).ToList();

            return Ok(result);
        }



        [HttpGet("RestaurantsByProductName/{name:regex(^[[a-zA-Z0-9\\s]]+$)}/")]
        public IActionResult GetRestaurantsOfProductByName(string name)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Name == name);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            return Ok(product.Restaurants);
        }



        [HttpGet("RestaurantsByProductNameWithDistance/{name:regex(^[[a-zA-Z0-9\\s]]+$)}/{latitude}/{longitude}")]
        public IActionResult GetRestaurantsOfProductByNameWithDistance(string name, double latitude, double longitude)
        {
            Product? product = DbRepository.Products.FirstOrDefault(p => p.Name == name);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            var result = product.Restaurants
                .Select(r => new
                {
                    Name = r.Name,
                    Distance = RestaurantController.GetDistanceInKm(latitude, longitude, r.latitude, r.longtude)
                }).ToList();

            return Ok(result);
        }
    }
}
