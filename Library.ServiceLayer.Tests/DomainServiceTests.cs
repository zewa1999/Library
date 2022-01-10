// ***********************************************************************
// Assembly         : Library.ServiceLayer.Tests
// Author           : costa
// Created          : 01-07-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="DomainServiceTests.cs" company="Library.ServiceLayer.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Library.ServiceLayer.Tests
{
    /// <summary>
    /// Defines test class DomainServiceTests.
    /// </summary>
    [TestClass]
    public class DomainServiceTests
    {
        /// <summary>
        /// The domain service mock
        /// </summary>
        private Mock<IDomainService> domainServiceMock;

        /// <summary>
        /// The domain service
        /// </summary>
        private IDomainService domainService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            domainServiceMock = new Mock<IDomainService>();
        }

        /// <summary>
        /// Defines the test method TestInsert.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };

            domainServiceMock.Setup(x => x.Insert(domain)).Returns(true);
            domainService = domainServiceMock.Object;

            var result = domainService.Insert(domain);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };

            domainServiceMock.Setup(x => x.GetAll(null, book => book.OrderBy(x => x.Id), null))
                .Returns(
                new List<Domain>()
                {domain});

            domainService = domainServiceMock.Object;

            var result = domainService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            var domain = new Domain()
            {
                Id = 1,
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };
            domainServiceMock.Setup(x => x.GetByID(1))
                .Returns(domain);

            domainService = domainServiceMock.Object;

            var result = domainService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Stiinta", result.Name);
            Assert.IsNull(result.ParentDomain);
            // etc
        }

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };

            domainServiceMock.Setup(x => x.GetByID(1))
                .Returns(domain);

            domainService = domainServiceMock.Object;

            var modifiedAccount = domainService.GetByID(1);
            modifiedAccount.Name = "Filozofie";

            domainServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = domainService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            domainServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            domainService = domainServiceMock.Object;

            var result = domainService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}