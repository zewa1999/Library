// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-08-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="UI.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;
using System;

namespace Proiect_.NET
{
    /// <summary>
    /// Class UI.
    /// </summary>
    public class UI
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(String[] args)
        {
            //var repo = new AccountRepository();
            //repo.Insert(new()
            //{
            //    PhoneNumber = "0734525427",
            //    Email = "validemail@gmail.com"
            //});
            Injector.Initialize();
            //var account = new Account()
            //{
            //    PhoneNumber = "0734525427",
            //    Email = "validemail@gmail.com"
            //};

            //var borrower = new Borrower()
            //{
            //    LastName = "Marcel",
            //    FirstName = "Gigel",
            //    Address = "Haidee",
            //    Account = account
            //};

            var borrowerService = Injector.Create<IBorrowerService>();
            //borrowerService.Insert(borrower);
            var borrower = borrowerService.GetByID(1);
            var email = borrower.Account.Email;
            Console.WriteLine(email);
        }
    }
}