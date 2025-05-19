using EMA_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMA_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DbRepository dbRepository = new DbRepository();
        [HttpPost("Add")]
        public IActionResult AddRestaurant([FromBody] Restaurant restaurant)
        {
            restaurant.Id = DbRepository.Restaurants.Count + 1;

            DbRepository.Restaurants.Add(restaurant);
            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }


        [HttpGet("GetRestaurant/{id:int}")]
        public IActionResult GetRestaurant(int id)
        {
            Restaurant? restaurant = DbRepository.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpGet("GetRestaurantByName/{name:regex(^[[a-zA-Z0-9\\s]]+$)}")]
        public IActionResult GetAction(string name)
        {
            Restaurant? restaurant = DbRepository.Restaurants.FirstOrDefault(r => r.Name == name);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }


        [HttpGet("GetAll")]
        public IActionResult GetRestaurants()
        {
            return Ok(DbRepository.Restaurants.Select(r => new { r.Id, r.Name }));
        }


        [HttpGet("check/{password}/{email}")]
        public IActionResult check([FromRoute]LoginModel login)
        {
            return Ok("Ok");
        }

        [HttpGet("Products/{id:int}")]
        public IActionResult GetProductsOfRestaurant(int id)
        {
            Restaurant? restaurant = DbRepository.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return BadRequest("Restaurant not found");
            }

            return Ok(restaurant.Products);
        }

        [HttpGet("Products/{name:regex(^[[a-zA-Z0-9\\s]]+$)}")]
        public IActionResult GetProductsOfRestaurant(string name)
        {
            Restaurant? restaurant = DbRepository.Restaurants.FirstOrDefault(r => r.Name == name);
            if (restaurant == null)
            {
                return BadRequest("Restaurant not found");
            }

            return Ok(restaurant.Products);
        }



        [HttpGet("AddProduct/{RestaurantId}/{ProductId}")]
        public IActionResult AddProductToRestaurant(int ProductId, int RestaurantId)
        {
            Product? Dbproduct = DbRepository.Products.FirstOrDefault(p => p.Id == ProductId);
            Restaurant? Dbrestaurant = DbRepository.Restaurants.FirstOrDefault(r => r.Id == RestaurantId);
            if ((Dbproduct == null) || (Dbrestaurant == null))
            {
                return BadRequest("Restaurant or Product is not Exist now");
            }

            Product product = new Product();
            Restaurant restaurant = new Restaurant();
            product.Id = ProductId;
            product.Name = Dbproduct.Name;
            restaurant.Id = RestaurantId;
            restaurant.Name = Dbrestaurant.Name;

            foreach(Product p in DbRepository.Products)
            {
                if(p.Id == ProductId)
                {
                    p.Restaurants.Add(restaurant);
                    break;
                }
            }

            foreach(Restaurant r in DbRepository.Restaurants)
            {
                if(r.Id == RestaurantId)
                {
                    r.Products.Add(product);
                    break;
                }
            }

            return Ok("product add to restaurant successfully");
        }
    }
}
