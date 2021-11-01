using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class DishDAO
    {
        public string Name { get; set; }

        public PriceDAO Price { get; set; }

        public DishDAO(Dish dish)
        {
            Name = dish.Name;
            Price = new PriceDAO(dish.Price);
        }

        public Dish ToAPIModel()
        {
            return new Dish()
            {
                Name = this.Name,
                Price = this.Price.ToAPIModel()
            };
        }
    }
}
