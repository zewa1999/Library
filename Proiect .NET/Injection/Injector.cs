using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_.NET.Injection
{
    public class Injector
    {
        private static StandardKernel _kernel;

        public static void Initialize()
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
        }

        public static T Create<T>()
        {
            return _kernel.Get<T>();
        }
    }
}