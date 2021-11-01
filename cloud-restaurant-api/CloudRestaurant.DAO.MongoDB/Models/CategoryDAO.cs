using CloudRestaurant.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class CategoryDAO
    {
        public string Name { get; set; }

        public IEnumerable<DishDAO> Dishes { get; set; }
        
        public CategoryDAO(Category category)
        {
            Name = category.Name;
            Dishes = category.Dishes.Select(dish => new DishDAO(dish));
        }

        public Category ToAPIModel()
        {
            return new Category()
            {
                Name = this.Name,
                Dishes = this.Dishes.Select(dish => dish.ToAPIModel())
            };
        }
    }
}
