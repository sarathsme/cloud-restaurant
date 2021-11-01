using System;
using System.Collections.Generic;
using System.Text;

namespace CloudRestaurant.Shared.Models
{
    public class Price
    {
        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public string UnitDisplayText { get; set; }
    }
}
