using CloudRestaurant.Shared.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class MenuDAO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CategoryDAO> Categories { get; set; }

        public MenuDAO(Menu menu)
        {
            if(!string.IsNullOrWhiteSpace(menu.Id))
            {
                Id = new ObjectId(menu.Id);
            }

            Name = menu.Name;
            Categories = menu.Categories.Select(category => new CategoryDAO(category));
        }

        public Menu ToAPIModel()
        {
            return new Menu()
            {
                Id = Id.ToString(),
                Name = this.Name,
                Categories = this.Categories.Select(category => category.ToAPIModel())
            };
        }
    }
}
