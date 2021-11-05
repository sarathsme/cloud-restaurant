using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CloudRestaurant.Shared.Models
{
    public class Price
    {
        [Required]
        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public string UnitDisplayText { get; set; }
    }
}
