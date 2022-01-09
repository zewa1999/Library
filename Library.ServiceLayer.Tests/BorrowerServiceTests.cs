// ***********************************************************************
// Assembly         : Library.ServiceLayer.Tests
// Author           : costa
// Created          : 01-07-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="BorrowerServiceTests.cs" company="Library.ServiceLayer.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Library.ServiceLayer.Tests
{
    /// <summary>
    /// Defines test class BorrowerServiceTests.
    /// </summary>
    [TestClass]
    public class BorrowerServiceTests
    {
        /// <summary>
        /// The borrower service mock
        /// </summary>
        private Mock<IBorrowerService> borrowerServiceMock;

        /// <summary>
        /// The borrower service
        /// </summary>
        private IBorrowerService borrowerService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            borrowerServiceMock = new Mock<IBorrowerService>();
        }

        /// <summary>
        /// Defines the test method TestInsert.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };

            borrowerServiceMock.Setup(x => x.Insert(borrower)).Returns(true);
            borrowerService = borrowerServiceMock.Object;

            var result = borrowerService.Insert(borrower);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };

            borrowerServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Borrower>()
                {borrower});

            borrowerService = borrowerServiceMock.Object;

            var result = borrowerService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var borrower = new Borrower()
            {
                Id = 1,
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };
            borrowerServiceMock.Setup(x => x.GetByID(1))
                .Returns(borrower);

            borrowerService = borrowerServiceMock.Object;

            var result = borrowerService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Gogu", result.LastName);
            Assert.AreEqual("Mortu", result.FirstName);
            // etc
        }

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };

            borrowerServiceMock.Setup(x => x.GetByID(1))
                .Returns(borrower);

            borrowerService = borrowerServiceMock.Object;

            var modifiedAccount = borrowerService.GetByID(1);
            modifiedAccount.LastName = "Alexandru";

            borrowerServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = borrowerService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            borrowerServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            borrowerService = borrowerServiceMock.Object;

            var result = borrowerService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}