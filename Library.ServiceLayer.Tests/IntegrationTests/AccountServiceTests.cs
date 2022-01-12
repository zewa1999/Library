// <copyright file="AccountServiceTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests.IntegrationTests
{
    using System.Linq;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Class AccountServiceTests.
    /// </summary>
    [TestClass]
    public class AccountServiceTests
    {
        private AccountService service;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            this.service = Injector.Create<AccountService>();
        }

        /// <summary>
        /// Defines the test method TestAccountInsert.
        /// </summary>
        [TestMethod]
        public void TestEndToEndAccount()
        {
            var account = new Account()
            {
                PhoneNumber = "1234567890",
                Email = "eunmailvalid@gmail.com",
            };

            // Insert
            Assert.IsTrue(this.service.Insert(account));

            // GetById intr-un fel, din cauza ca adauga prea multe in baza de date..
            var dbAccount = this.service.GetAll(null, null, string.Empty).LastOrDefault();
            Assert.IsNotNull(dbAccount);
            Assert.IsNotNull(this.service.GetByID(dbAccount.Id));

            // GetAll
            var allAccounts = this.service.GetAll(null, null, string.Empty);
            Assert.IsNotNull(allAccounts);

            // Update
            dbAccount.Email = "validmain123@mail.com";
            Assert.IsTrue(this.service.Update(dbAccount));

            // Delete
            Assert.IsTrue(this.service.DeleteById(dbAccount.Id));

            // Clean table
            Assert.IsTrue(this.service.DeleteAll());
        }
    }
}