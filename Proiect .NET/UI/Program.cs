// ***********************************************************************
// Assembly         : Library.UI
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 11-29-2021
// ***********************************************************************
// <copyright file="Program.cs" company="Library.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.Concretes;
using Library.DataLayer.Interfaces;
using Library.ServiceLayer.Services;
using Proiect_.NET;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.UI
{
    /// <summary>
    /// Class Program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Injector.Initialize();
            IPropertiesRepository repo = Injector.Create<PropertiesRepository>();
        }
    }
}