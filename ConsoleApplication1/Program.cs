using System;

using DiamondCostCalculator.Core;
using DiamondCostCalculator.Core.Command.Implementations;
using DiamondCostCalculator.Core.OrderInfo;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new DefaultCommand();
            Console.WriteLine(command.Execute(new Order(Shape.Fantasy, Quality.A, Discount.BaguetteSquareTrilliant, "Red", "Clean")));
            Console.ReadKey();
        }
    }
}
