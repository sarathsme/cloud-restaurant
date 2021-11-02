﻿using CloudRestaurant.Shared.Models;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class DishDAO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public PriceDAO Price { get; set; }

        public decimal? UserRating { get; set; }

        public DishDAO(Dish dish)
        {
            Name = dish.Name;
            Description = dish.Description;
            IsAvailable = dish.IsAvailable;
            Price = new PriceDAO(dish.Price);
            UserRating = dish.UserRating;
        }

        public Dish ToAPIServiceModel()
        {
            return new Dish()
            {
                Name = Name,
                Description = Description,
                IsAvailable = IsAvailable,
                Price = Price.ToAPIServiceModel(),
                UserRating = UserRating
            };
        }
    }
}
