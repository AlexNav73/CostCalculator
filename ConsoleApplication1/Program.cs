using System;

using DiamondCostCalculator.Core;
using DiamondCostCalculator.Core.OrderInfo;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order(Shape.Fantasy, Quality.A, Discount.BaguetteSquareTrilliant, "Red", "Clean");
            order.Test();

            Console.ReadKey();
        }
    }
}
