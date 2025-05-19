namespace EMA_Project.Models
{
    public class DbRepository
    {
        public static List<SignUpModel> Users = new List<SignUpModel>();
        public static List<Restaurant> Restaurants = new List<Restaurant>();
        public static List<Product> Products = new List<Product>();

        public static SignUpModel? CurrentUser { get; set; } = null;

        public DbRepository()
        {
            if(Users.Count > 0 && Restaurants.Count > 0 && Products.Count > 0)
                return;


            Users.Add(new SignUpModel() {
                Id = 1,
                Name = "ahmed",
                Gender = true,
                Email = "ahmed@gmail.com",
                Level = 4,
                Password = "12345678",
                Rule = "Admin"
            });

            Restaurants.Add(new Restaurant { Id = 1, Name = "Bazooka", latitude = 30.0444, longtude = 31.2357 });
            Restaurants.Add(new Restaurant { Id = 2, Name = "El Tahre", latitude = 30.0550, longtude = 31.2800 });
            
            Products.Add(new Product { Id = 1, Name = "burger", Price = 300.0m }); 
            Products.Add(new Product { Id = 2, Name = "cheese burger", Price = 10.0m }); 
            Products.Add(new Product { Id = 3, Name = "Koshari", Price = 5.0m });
            Products.Add(new Product { Id = 4, Name = "7awawshy", Price = 5.0m });

            Restaurant r1 = new Restaurant() { Id = 1, Name = "Bazooka", latitude = 30.0444, longtude = 31.2357 };
            Restaurant r2 = new Restaurant() { Id = 2, Name = "El Tahre", latitude = 30.0550, longtude = 31.2800 };
            Product p1 = new Product() { Id = 1, Name = "burger", Price = 300.0m };
            Product p2 = new Product() { Id = 2, Name = "cheese burger", Price = 10.0m };
            Product p3 = new Product() { Id = 3, Name = "Koshari", Price = 5.0m };
            Product p4 = new Product() { Id = 4, Name = "7awawshy", Price = 5.0m };

            Restaurants[0]?.Products?.Add(p1);
            Restaurants[0]?.Products?.Add(p2);
            Products[0]?.Restaurants?.Add(r1);
            Products[1]?.Restaurants?.Add(r1);

            Restaurants[1]?.Products?.Add(p3);
            Restaurants[1]?.Products?.Add(p4);
            Products[2]?.Restaurants?.Add(r2);
            Products[3]?.Restaurants?.Add(r2);
        }
    }
}
