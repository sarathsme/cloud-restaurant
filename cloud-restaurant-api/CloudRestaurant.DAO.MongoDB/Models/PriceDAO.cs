using CloudRestaurant.Shared.Models;

namespace CloudRestaurant.DAO.MongoDB.Models
{
    public class PriceDAO
    {
        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public string UnitDisplayText { get; set; }

        public PriceDAO(Price price)
        {
            Quantity = price.Quantity;
            Unit = price.Unit;
            UnitDisplayText = price.UnitDisplayText;
        }

        public Price ToAPIServiceModel()
        {
            return new Price()
            {
                Quantity = this.Quantity,
                Unit = this.Unit,
                UnitDisplayText = this.UnitDisplayText
            };
        }
    }
}
