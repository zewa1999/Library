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
            var borrowerService = Injector.Create<IBorrowerService>();
            var account = new Account()
            {
                PhoneNumber = "0732456789",
                Email = "ado@net.com"
            };
            service.Insert(account);

            var borrower = new Borrower()
            {
                LastName = "Marcel",
                FirstName = "Garcea",
                Address = "Alexandru ioan cuza nr 5",
                Account = account
            };

            borrowerService.Insert(borrower);
        }
    }
}