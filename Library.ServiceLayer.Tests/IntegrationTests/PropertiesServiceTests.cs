// <copyright file="PropertiesServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines test class PropertyServiceTests.
    /// </summary>
    [TestClass]
    public class PropertiesServiceTests
    {
        private PropertiesService service;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            this.service = Injector.Create<PropertiesService>();
        }

        /// <summary>
        /// Defines the test method EndToEndProperties.
        /// </summary>
        [TestMethod]
        public void EndToEndProperties()
        {
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 3,
                L = 2,
                C = 3,
                D = 2,
                LIM = 2,
                DELTA = 3,
                NCZ = 4,
                PERSIMP = 3,
                PER = 3,
            };

            // Insert
            Assert.IsTrue(this.service.Insert(properties));

            // GetById intr-un fel, din cauza ca adauga prea multe in baza de date..
            var dbProperties = this.service.GetAll(null, null, string.Empty).LastOrDefault();
            Assert.IsNotNull(dbProperties);
            Assert.IsNotNull(this.service.GetByID(dbProperties.Id));

            // GetAll
            var allProperties = this.service.GetAll(null, null, string.Empty);
            Assert.IsNotNull(allProperties);

            // Update
            properties.NMC = 2;
            properties.PER = 8;
            Assert.IsTrue(this.service.Update(dbProperties));

            // Delete
            Assert.IsTrue(this.service.DeleteById(dbProperties.Id));
        }

        /// <summary>
        /// Defines the test method InsertBadData.
        /// </summary>
        [TestMethod]
        public void InsertBadData()
        {
            var properties = new Properties()
            {
                DOMENII = -2,
            };

            Assert.IsFalse(this.service.Insert(properties));
        }

        /// <summary>
        /// Defines the test method UpdateBadData.
        /// </summary>
        [TestMethod]
        public void UpdateBadData()
        {
            var properties = new Properties()
            {
                DOMENII = -2,
            };

            Assert.IsFalse(this.service.Update(properties));
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
