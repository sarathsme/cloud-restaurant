using System.Collections.Generic;

namespace CloudRestaurant.Shared.Models
{
    public class Menu
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Dish> UncategorizedDishes { get; set; }
    }
}
