// <copyright file="BorrowerServiceTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests.IntegrationTests
{
    using System;
    using System.Linq;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Defines test class BorrowerServiceTests.
    /// </summary>
    [TestClass]
    public class BorrowerServiceTests
    {
        private BorrowerService service;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            this.service = Injector.Create<BorrowerService>();
        }

        /// <summary>
        /// Defines the test method EndToEndBorrower.
        /// </summary>
        [TestMethod]
        public void EndToEndBorrower()
        {
            var service = Injector.Create<BorrowerService>();

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com",
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
            };

            // Insert
            Assert.IsTrue(this.service.Insert(borrower));

            // GetById intr-un fel, din cauza ca adauga prea multe in baza de date..
            var dbBorrower = this.service.GetAll(null, null, string.Empty).LastOrDefault();
            Assert.IsNotNull(dbBorrower);
            Assert.IsNotNull(this.service.GetByID(dbBorrower.Id));

            // GetAll
            var allBorrowers = this.service.GetAll(null, null, string.Empty);
            Assert.IsNotNull(allBorrowers);

            // Update
            dbBorrower.Address = "strada Gneral Mihai";
            dbBorrower.Account.Email = "mihaialex@gmail.com";

            Assert.IsTrue(this.service.Update(dbBorrower));

            // Delete
            Assert.IsTrue(this.service.DeleteById(dbBorrower.Id));
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            // Clean librarian table
            Assert.IsTrue(this.service.DeleteAll());

            // Clean account table
            var accountService = Injector.Create<AccountService>();
            Assert.IsTrue(accountService.DeleteAll());
        }
    }
}
