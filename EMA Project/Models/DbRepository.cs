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
            Restaurants.Add(new Restaurant { Id = 2, Name = "Buffalo", latitude = 30.0450, longtude = 31.2500 });
            Restaurants.Add(new Restaurant { Id = 3, Name = "Heart Attack", latitude = 30.0500, longtude = 31.2700 });
            Restaurants.Add(new Restaurant { Id = 4, Name = "El Tahre", latitude = 30.0550, longtude = 31.2800 });
            
            Products.Add(new Product { Id = 1, Name = "burger", Price = 300.0m }); 
            Products.Add(new Product { Id = 2, Name = "rice", Price = 10.0m }); 
            Products.Add(new Product { Id = 3, Name = "Macarona", Price = 5.0m });
            Products.Add(new Product { Id = 4, Name = "Pizza", Price = 5.0m });
            Products.Add(new Product { Id = 5, Name = "Shawerma La7ma", Price = 5.0m });
            Products.Add(new Product { Id = 6, Name = "Shawerma Fera5", Price = 5.0m });

            for(int i = 0; i < Products.Count; i++)
            {
                Product p = new Product { Id = Products[i].Id, Name = Products[i].Name, Price = Products[i].Price };
                for (int j=0; j<Restaurants.Count; j++)
                {
                    Restaurants[j]?.Products?.Add(p);
                }
            }
            for (int i = 0; i < Restaurants.Count; i++)
            {
                Restaurant r = new Restaurant { Id = Restaurants[i].Id, Name = Restaurants[i].Name };
                for (int j = 0; j < Products.Count; j++)
                {
                    Products[j]?.Restaurants?.Add(r);
                }
            }
        }
    }
}
