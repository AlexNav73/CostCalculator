using DiamondCostCalculator.DocumentContract;
using DiamondCostCalculator.DocumentProvider.Word;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DiamondCostCalculator.DependencyResolver
{
    public static class Container
    {
        private static StandardKernel _kernel = null;

        static Container()
        {
            _kernel = new StandardKernel();
            _kernel.Load(new Dependencies());
        }

        public static T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public static T Resolve<T>(Type type)
        {
            return (T)_kernel.Get(type);
        }

        public static T Resolve<T>(string type)
        {
            return (T)_kernel.Get(InterfaceHelper.GetInterfaceType(type));
        }
    }
}
