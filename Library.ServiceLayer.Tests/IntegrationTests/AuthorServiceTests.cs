// <copyright file="AuthorServiceTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests.IntegrationTests
{
    using System.Linq;
    using Library.DomainLayer;
    using Library.ServiceLayer.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Defines test class AuthorServiceTests.
    /// </summary>
    [TestClass]
    public class AuthorServiceTests
    {
        private AuthorService service;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            this.service = Injector.Create<AuthorService>();
        }

        /// <summary>
        /// Defines the test method EndToEndAuthor.
        /// </summary>
        [TestMethod]
        public void EndToEndAuthor()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            // Insert
            Assert.IsTrue(this.service.Insert(author));

            // GetById intr-un fel, din cauza ca adauga prea multe in baza de date..
            var dbAccount = this.service.GetAll(null, null, string.Empty).LastOrDefault();
            Assert.IsNotNull(dbAccount);
            Assert.IsNotNull(this.service.GetByID(dbAccount.Id));

            // GetAll
            var allAccounts = this.service.GetAll(null, null, string.Empty);
            Assert.IsNotNull(allAccounts);

            // Update
            dbAccount.LastName = "Garcea";
            Assert.IsTrue(this.service.Update(dbAccount));

            // Delete
            Assert.IsTrue(this.service.DeleteById(dbAccount.Id));
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            // Clean table
            Assert.IsTrue(this.service.DeleteAll());
        }
    }
}
