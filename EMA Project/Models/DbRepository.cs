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

            Restaurants.Add(new Restaurant { Id = 1, Name = "Bazooka" });
            Restaurants.Add(new Restaurant { Id = 2, Name = "Buffalo" });
            Restaurants.Add(new Restaurant { Id = 3, Name = "Heart Attack" });
            Restaurants.Add(new Restaurant { Id = 4, Name = "El-Tahre" });
            Restaurants.Add(new Restaurant { Id = 5, Name = "Belabn" });
            Restaurants.Add(new Restaurant { Id = 6, Name = "Gad" });
            Restaurants.Add(new Restaurant { Id = 7, Name = "Hardees" });
            Restaurants.Add(new Restaurant { Id = 8, Name = "El-Abd" });
            Restaurants.Add(new Restaurant { Id = 9, Name = "Etwal" });
            
            Products.Add(new Product { Id = 1, Name = "Roz Blabn", Price = 20.0m}); 
            Products.Add(new Product { Id = 2, Name = "Hamburger", Price = 300.0m }); 
            Products.Add(new Product { Id = 3, Name = "rice", Price = 10.0m }); 
            Products.Add(new Product { Id = 4, Name = "salad", Price = 5.0m }); 
            Products.Add(new Product { Id = 5, Name = "Koshari", Price = 5.0m });
            Products.Add(new Product { Id = 6, Name = "El Mesa5sa5a", Price = 5.0m });
            Products.Add(new Product { Id = 7, Name = "Macarona", Price = 5.0m });
            Products.Add(new Product { Id = 8, Name = "Pizza", Price = 5.0m });
            Products.Add(new Product { Id = 9, Name = "Shawerma La7ma", Price = 5.0m });
            Products.Add(new Product { Id = 10, Name = "Shawerma Fera5", Price = 5.0m });

            Restaurants[0].Products = new List<Product>() { Products[0], Products[1], Products[2], Products[3]};
            Restaurants[1].Products = new List<Product>() { Products[1], Products[2], Products[3], Products[4] };
            Restaurants[2].Products = new List<Product>() { Products[5], Products[6], Products[7], Products[8] };
            Restaurants[3].Products = new List<Product>() { Products[0], Products[1], Products[2], Products[3] };
            Restaurants[4].Products = new List<Product>() { Products[0], Products[9], Products[8], Products[5] };
            Restaurants[5].Products = new List<Product>() { Products[1], Products[8], Products[2], Products[5] };
            Restaurants[6].Products = new List<Product>() { Products[2], Products[6], Products[3], Products[5] };
            Restaurants[7].Products = new List<Product>() { Products[3], Products[7], Products[8], Products[5] };
            Restaurants[8].Products = new List<Product>() { Products[4], Products[2], Products[9], Products[5] };

        }
    }
}
