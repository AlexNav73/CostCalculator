using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiamondCostCalculator.DependencyResolver
{
    public static class Resolver
    {
        private static StandardKernel _kernel = null;

        static Resolver()
        {
            _kernel = new StandardKernel();
            _kernel.Load(new Dependencies());
        }

        public static T Resolve<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
