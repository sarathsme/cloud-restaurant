using CloudRestaurant.Shared.Models;
using System.Collections.Generic;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class DishDAO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public PriceDAO Price { get; set; }

        public decimal? UserRating { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string ImageUrl { get; set; }

        public DishDAO(Dish dish)
        {
            Name = dish.Name;
            Description = dish.Description;
            IsAvailable = dish.IsAvailable;
            Price = new PriceDAO(dish.Price);
            UserRating = dish.UserRating;
            Tags = dish.Tags;
            ImageUrl = dish.ImageUrl;
        }

        public Dish ToAPIServiceModel()
        {
            return new Dish()
            {
                Name = Name,
                Description = Description,
                IsAvailable = IsAvailable,
                Price = Price.ToAPIServiceModel(),
                UserRating = UserRating,
                Tags = Tags,
                ImageUrl = ImageUrl
            };
        }
    }
}
