// ***********************************************************************
// Assembly         : Library.ServiceLayer.Tests
// Author           : costa
// Created          : 01-09-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="PropertyServiceTests.cs" company="Library.ServiceLayer.Tests">
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
    /// Defines test class PropertyServiceTests.
    /// </summary>
    [TestClass]
    public class PropertyServiceTests
    {
        /// <summary>
        /// The properties service mock
        /// </summary>
        private Mock<IPropertiesService> propertiesServiceMock;

        /// <summary>
        /// The properties service
        /// </summary>
        private IPropertiesService propertiesService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            propertiesServiceMock = new Mock<IPropertiesService>();
        }

        /// <summary>
        /// Defines the test method TestInsert.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            var properties = new Properties()
            {
                Domenii = 2,
                NumarMaximCarti = 3,
                L = 2,
                NrMaximCartiImprumutate = 3,
                NrMaximCartiImprumutateAcelasiDomeniu = 2,
                LimitaMaximaImprumut = 2,
                Delta = 3,
                NumarCartiImprumutateZilnic = 4,
                Persimp = 3
            };

            propertiesServiceMock.Setup(x => x.Insert(properties)).Returns(true);
            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.Insert(properties);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            propertiesServiceMock.Setup(x => x.GetAll(null, book => book.OrderBy(x => x.Id), null))
                .Returns(
                new List<Properties>()
                { new Properties {
                    Domenii = 2,
                NumarMaximCarti = 3,
                L = 2,
                NrMaximCartiImprumutate = 3,
                NrMaximCartiImprumutateAcelasiDomeniu = 2,
                LimitaMaximaImprumut = 2,
                Delta = 3,
                NumarCartiImprumutateZilnic = 4,
                Persimp = 3}
                });

            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            propertiesServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Properties
                {
                    Id = 1,
                    Domenii = 2,
                    NumarMaximCarti = 3,
                    L = 2,
                    NrMaximCartiImprumutate = 3,
                    NrMaximCartiImprumutateAcelasiDomeniu = 2,
                    LimitaMaximaImprumut = 2,
                    Delta = 3,
                    NumarCartiImprumutateZilnic = 4,
                    Persimp = 3
                });

            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(2, result.Domenii);
            Assert.AreEqual(3, result.NumarMaximCarti);
            // etc
        }

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            propertiesServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Properties
                {
                    Domenii = 2,
                    NumarMaximCarti = 3,
                    L = 2,
                    NrMaximCartiImprumutate = 3,
                    NrMaximCartiImprumutateAcelasiDomeniu = 2,
                    LimitaMaximaImprumut = 2,
                    Delta = 3,
                    NumarCartiImprumutateZilnic = 4,
                    Persimp = 3
                });

            propertiesService = propertiesServiceMock.Object;

            var modifiedAccount = propertiesService.GetByID(1);
            modifiedAccount.Domenii = 7;

            propertiesServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = propertiesService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            propertiesServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}