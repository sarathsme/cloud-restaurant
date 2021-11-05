using CloudRestaurant.Shared.Models;
using EnsureThat;
using System;
using System.Collections.Generic;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class DishDAO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public bool IsAvailable { get; set; }

        public PriceDAO Price { get; set; }

        public decimal? UserRating { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string ImageUrl { get; set; }

        public List<string> AvailableTimeOfDay { get; set; }

        public int WaitingTime { get; set; }

        public DishDAO(Dish dish)
        {
            EnsureArg.IsNotNull(dish, nameof(dish));

            Id = dish.Id ?? Guid.NewGuid();
            Name = dish.Name;
            Description = dish.Description;
            Category = dish.Category;
            IsAvailable = dish.IsAvailable;
            Price = dish.Price != null ? new PriceDAO(dish.Price) : null;
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
                Category = Category,
                IsAvailable = IsAvailable,
                Price = Price?.ToAPIServiceModel(),
                UserRating = UserRating,
                Tags = Tags,
                ImageUrl = ImageUrl,
                AvailableTimeOfDay = AvailableTimeOfDay,
                WaitingTime = WaitingTime
            };
        }
    }
}
