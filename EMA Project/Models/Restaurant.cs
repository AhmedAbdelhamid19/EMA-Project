using System.ComponentModel.DataAnnotations;

namespace EMA_Project.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double latitude { get; set; }
        [Required]
        public double longtude { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
