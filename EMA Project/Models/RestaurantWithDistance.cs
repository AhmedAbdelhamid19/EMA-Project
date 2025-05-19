namespace EMA_Project.Models
{
    public class RestaurantWithDistance
    {
        public string Name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double DistanceToUser { get; set; }
    }
}
