using System.ComponentModel.DataAnnotations;

namespace EMA_Project.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<Restaurant>? Restaurants { get; set; } = new List<Restaurant>();
    }
}
