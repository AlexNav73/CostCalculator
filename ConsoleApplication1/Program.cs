using DiamondCostCalculator.Core;
using DiamondCostCalculator.Core.Command.Implementations;
using DiamondCostCalculator.Core.OrderInfo;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        class MyClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public double Height { get; set; }
        }

        static void Main(string[] args)
        {
            var command = new DefaultCommand();
            Console.WriteLine(command.Execute(new Order(Shape.Fantasy, Quality.A, Discount.BaguetteSquareTrilliant, "Red", "Clean")));
            Console.ReadKey();
        }
    }
}
