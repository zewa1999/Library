// <copyright file="Injector.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Proiect_.NET.Injection
{
    using Ninject;
    using System.Reflection;

    /// <summary>
    /// Class Injector.
    /// </summary>
    public class Injector
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private static StandardKernel kernel;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T Create<T>()
        {
            return kernel.Get<T>();
        }
    }
}