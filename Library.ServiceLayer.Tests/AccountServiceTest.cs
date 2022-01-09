// ***********************************************************************
// Assembly         : Library.ServiceLayer.Tests
// Author           : costa
// Created          : 01-07-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="AccountServiceTest.cs" company="Library.ServiceLayer.Tests">
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
    /// Defines test class AccountServiceTest.
    /// </summary>
    [TestClass]
    public class AccountServiceTest
    {
        /// <summary>
        /// The account service mock
        /// </summary>
        private Mock<IAccountService> accountServiceMock;

        /// <summary>
        /// The account service
        /// </summary>
        private IAccountService accountService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            accountServiceMock = new Mock<IAccountService>();
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
                Email = "validemail@gmail.com"
            };

            accountServiceMock.Setup(x => x.Insert(account)).Returns(true);
            accountService = accountServiceMock.Object;

            var result = accountService.Insert(account);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            accountServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Account>()
                { new Account {
                    PhoneNumber = "0734525427",
                    Email = "validemail@gmail.com"}
                });

            accountService = accountServiceMock.Object;

            var result = accountService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            accountServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Account
                {
                    Id = 1,
                    PhoneNumber = "0734525427",
                    Email = "validemail@gmail.com"
                });

            accountService = accountServiceMock.Object;

            var result = accountService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("0734525427", result.PhoneNumber);
            Assert.AreEqual("validemail@gmail.com", result.Email);
        }

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            accountServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Account
                {
                    PhoneNumber = "0734525427",
                    Email = "validemail@gmail.com"
                });

            accountService = accountServiceMock.Object;

            var modifiedAccount = accountService.GetByID(1);
            modifiedAccount.Email = "modifiedemail@gmail.ro";

            accountServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = accountService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            accountServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            accountService = accountServiceMock.Object;

            var result = accountService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}