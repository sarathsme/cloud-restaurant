using CloudRestaurant.Shared.Models;
using System;
using System.Collections.Generic;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class DishDAO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public PriceDAO Price { get; set; }

        public decimal? UserRating { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string ImageUrl { get; set; }

        public List<string> AvailableTimeOfDay { get; set; }

        public int WaitingTime { get; set; }

        public DishDAO(Dish dish)
        {
            Id = dish.Id ?? Guid.NewGuid();
            Name = dish.Name;
            Description = dish.Description;
            IsAvailable = dish.IsAvailable;
            Price = new PriceDAO(dish.Price);
            UserRating = dish.UserRating;
            Tags = dish.Tags;
            ImageUrl = dish.ImageUrl;
            AvailableTimeOfDay = dish.AvailableTimeOfDay;
            WaitingTime = dish.WaitingTime;
        }

        public Dish ToAPIServiceModel()
        {
            return new Dish()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                IsAvailable = IsAvailable,
                Price = Price.ToAPIServiceModel(),
                UserRating = UserRating,
                Tags = Tags,
                ImageUrl = ImageUrl,
                AvailableTimeOfDay = AvailableTimeOfDay,
                WaitingTime = WaitingTime
            };
        }
    }
}
