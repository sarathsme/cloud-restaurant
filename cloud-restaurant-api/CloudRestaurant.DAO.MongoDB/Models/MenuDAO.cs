using CloudRestaurant.DAO.MongoDB.Utils;
using CloudRestaurant.Shared.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class MenuDAO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }

        public IEnumerable<CategoryDAO> Categories { get; set; }

        public IEnumerable<DishDAO> UncategorizedDishes { get; set; }

        public MenuDAO(Menu menu)
        {
            //TODO: Add custom exceptions, null checks
            if(!string.IsNullOrWhiteSpace(menu.Id))
            {
                Id = menu.Id.ToObjectId() ?? throw new ArgumentException("Invalid Menu ID");
            }

            IsEnabled = menu.IsEnabled;             
            Name = menu.Name;
            Description = menu.Description;
            Categories = menu.Categories.Select(category => new CategoryDAO(category));
            UncategorizedDishes = menu.UncategorizedDishes.Select(dish => new DishDAO(dish));
        }

        public Menu ToAPIServiceModel()
        {
            return new Menu()
            {
                Id = Id != ObjectId.Empty ? Id.ToString() : null,
                IsEnabled = IsEnabled,
                Name = Name,
                Description = Description,
                Categories = Categories.Select(category => category.ToAPIServiceModel()),
                UncategorizedDishes = UncategorizedDishes.Select(dish => dish.ToAPIServiceModel())
            };
        }
    }
}
