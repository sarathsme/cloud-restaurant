using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Models
{
    public class Category
    {
        public string Name { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }
    }
}
