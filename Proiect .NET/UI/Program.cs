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
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
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
            var service = Injector.Create<IAccountService>();
            var account = new Account()
            {
                PhoneNumber = "074124sda324s",
                Email = "Ado.231net.com"
            };

            service.Insert(account);
        }
    }
}