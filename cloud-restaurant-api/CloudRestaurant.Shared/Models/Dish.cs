namespace CloudRestaurant.Shared.Models
{
    public class Dish
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public Price Price { get; set; }
    }
}
