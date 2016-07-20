using DiamondCostCalculator.Core.OrderInfo;

namespace DiamondCostCalculator.Core
{
    public class Order
    {
        public Shape Shape { get; set; }
        public Quality Quality { get; set; }
        public Discount Discount { get; set; }
        public string Color { get; set; }
        public string Purity { get; set; }

        public Order(Shape shape, Quality quality, Discount discount, string color, string purity)
        {
            Shape = shape;
            Quality = quality;
            Discount = discount;
            Color = color;
            Purity = purity;
        }
    }
}
