// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Injector.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

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
        private static StandardKernel _kernel;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static T Create<T>()
        {
            return _kernel.Get<T>();
        }
    }
}