using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudRestaurant.Shared.Models
{
    public class Menu
    {
        //TODO: Long?
        public string Id { get; set; }

        public string Name { get; set; }

        //IEnumerable?
        public List<Dish> Dishes { get; set;}
    }
}
