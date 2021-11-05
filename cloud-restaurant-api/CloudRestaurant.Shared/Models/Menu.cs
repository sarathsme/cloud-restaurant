using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CloudRestaurant.Shared.Models
{
    public class Menu
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public bool? IsEnabled { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }
    }
}
