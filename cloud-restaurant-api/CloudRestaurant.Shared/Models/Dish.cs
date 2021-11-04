using System.Collections.Generic;

namespace CloudRestaurant.Shared.Models
{
    public class Dish
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public Price Price { get; set; }

        /// <summary>
        /// Average rating this received from customers out of 5
        /// </summary>
        public decimal? UserRating { get; set; }

        /// <summary>
        /// Any tags or labels for the dish like - Healthy, Chef's choice, Best seller, etc.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Absolute or relative URL for the image
        /// </summary>
        public string ImageUrl { get; set; }


        /// <summary>
        /// Time of day the dish will be available like - breakfast, lunch, dinner, weekend, etc.
        /// </summary>
        public List<string> AvailableTimeOfDay { get; set; }

        /// <summary>
        /// Amount of time the customer has to wait before the food will be available in SECONDS
        /// </summary>
        public int WaitingTime { get; set; }
    }
}
