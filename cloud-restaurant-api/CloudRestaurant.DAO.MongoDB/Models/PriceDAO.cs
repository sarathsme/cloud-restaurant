using CloudRestaurant.Shared.Models;
using EnsureThat;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class PriceDAO
    {
        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public string UnitDisplayText { get; set; }

        public PriceDAO(Price price)
        {
            EnsureArg.IsNotNull(price, nameof(price));

            Quantity = price.Quantity;
            Unit = price.Unit;
            UnitDisplayText = price.UnitDisplayText;
        }

        public Price ToAPIServiceModel()
        {
            return new Price()
            {
                Quantity = Quantity,
                Unit = Unit,
                UnitDisplayText = UnitDisplayText
            };
        }
    }
}
