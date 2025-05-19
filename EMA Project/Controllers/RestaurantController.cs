using EMA_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Math;

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





        [HttpGet("ProductsByRestaurantName/{name:regex(^[[a-zA-Z0-9\\s]]+$)}")]
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





        [HttpGet("CalcDistanceByRestaurantId/{latitude}/{longitude}/{RestaurantId:int}")]
        public IActionResult CalcDistancdById(int latitude, int longitude, int RestaurantId)
        {
            Restaurant? restaurant = DbRepository.Restaurants.FirstOrDefault(r => r.Id == RestaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }


            double Distance = GetDistanceInKm(latitude, longitude, restaurant.latitude, restaurant.longtude);
            return Ok(new { Distance = Distance });
        }



        [HttpGet("CalcDistanceByRestaurantName/{latitude}/{longitude}/{RestaurantName}")]
        public IActionResult CalcDistancdByName(int latitude, int longitude, string RestaurantName)
        {
            Restaurant? restaurant = DbRepository.Restaurants.FirstOrDefault(r => r.Name == RestaurantName);
            if (restaurant == null)
            {
                return NotFound();
            }

            double Distance = GetDistanceInKm(latitude, longitude, restaurant.latitude, restaurant.longtude);
            return Ok(new { Distance = Distance });
        }


        public static double GetDistanceInKm(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Earth's radius in kilometers

            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }


}
