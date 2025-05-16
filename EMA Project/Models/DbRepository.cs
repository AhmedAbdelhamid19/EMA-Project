namespace EMA_Project.Models
{
    public class DbRepository
    {
        public static List<SignUpModel> Users = new List<SignUpModel>();
        public static List<Restaurant> Restaurants = new List<Restaurant>();
        public static List<Product> Products = new List<Product>();

        public static SignUpModel? CurrentUser { get; set; } = null;

        DbRepository()
        {
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
            Restaurants[4]?.Products?.Add(Products[0]);
            Products.Add(new Product { Id = 2, Name = "Hamburger", Price = 300.0m }); 
            Restaurants[0]?.Products?.Add(Products[1]);
            Products.Add(new Product { Id = 3, Name = "rice", Price = 10.0m }); 
            Restaurants[0]?.Products?.Add(Products[2]);
            Products.Add(new Product { Id = 4, Name = "salad", Price = 5.0m }); 
            Restaurants[0]?.Products?.Add(Products[3]);
            Products.Add(new Product { Id = 5, Name = "Koshari", Price = 5.0m }); 
            Restaurants[3]?.Products?.Add(Products[4]);
        }
    }
}
