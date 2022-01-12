// <copyright file="DomainServiceTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Defines test class DomainServiceTests.
    /// </summary>
    [TestClass]
    public class DomainServiceTests
    {
        private DomainService service;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            this.service = Injector.Create<DomainService>();
        }

        /// <summary>
        /// Ends to end domain.
        /// </summary>
        [TestMethod]
        public void EndToEndDomain()
        {
            var domain = new Domain()
            {
                Name = "Literatura",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>(),
            };

            // Insert
            Assert.IsTrue(this.service.Insert(domain));

            // GetById intr-un fel, din cauza ca adauga prea multe in baza de date..
            var dbDomain = this.service.GetAll(null, null, string.Empty).LastOrDefault();
            Assert.IsNotNull(dbDomain);
            Assert.IsNotNull(this.service.GetByID(dbDomain.Id));

            // GetAll
            var allDomains = this.service.GetAll(null, null, string.Empty);
            Assert.IsNotNull(allDomains);

            // Update
            if (dbDomain.ChildrenDomains == null)
            {
                dbDomain.ChildrenDomains = new List<Domain>();
                dbDomain.ChildrenDomains.Add(
                    new Domain()
                    {
                        Name = "Proza",
                        ParentDomain = domain,
                        ChildrenDomains = new List<Domain>(),
                    });
            }
            else if (dbDomain.ChildrenDomains.Count == 0)
            {
                dbDomain.ChildrenDomains.Add(
                    new Domain()
                    {
                        Name = "Proza",
                        ParentDomain = domain,
                        ChildrenDomains = new List<Domain>(),
                    });
            }
            else
            {
                dbDomain.ChildrenDomains.Add(
                    new Domain()
                    {
                        Name = "Proza",
                        ParentDomain = domain,
                        ChildrenDomains = new List<Domain>(),
                    });
            }

            dbDomain.Name = "Stiinta";
            Assert.IsTrue(this.service.Update(dbDomain));

            // Delete
            Assert.IsTrue(this.service.DeleteById(dbDomain.Id));

            // Clean table
            Assert.IsTrue(this.service.DeleteAll());
        }

        /// <summary>
        /// Defines the test method InsertDomainInvalid.
        /// </summary>
        [TestMethod]
        public void InsertDomainInvalid()
        {
            var domain = new Domain()
            {
                Name = string.Empty,
                ParentDomain = null,
                ChildrenDomains = null,
            };

            Assert.IsFalse(this.service.Insert(domain));
        }
    }
}
