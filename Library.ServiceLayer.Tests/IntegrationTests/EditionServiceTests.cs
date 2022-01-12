// <copyright file="EditionServiceTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests.IntegrationTests
{
    using System;
    using System.Linq;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Defines test class EditionServiceTests.
    /// </summary>
    [TestClass]
    public class EditionServiceTests
    {
        private EditionService service;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            this.service = Injector.Create<EditionService>();
        }

        /// <summary>
        /// Defines the test method EndToEndEdition.
        /// </summary>
        [TestMethod]
        public void EndToEndEdition()
        {
            var edition = new Edition()
            {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 5,
            };

            // Insert
            Assert.IsTrue(this.service.Insert(edition));

            // GetById intr-un fel, din cauza ca adauga prea multe in baza de date..
            var dbAccount = this.service.GetAll(null, null, string.Empty).LastOrDefault();
            Assert.IsNotNull(dbAccount);
            Assert.IsNotNull(this.service.GetByID(dbAccount.Id));

            // GetAll
            var allEditions = this.service.GetAll(null, null, string.Empty);
            Assert.IsNotNull(allEditions);

            // Update
            edition.Year = "2072";
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
