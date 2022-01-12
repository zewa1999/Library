// <copyright file="AccountServiceTest.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.IServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Defines test class AccountServiceTest.
    /// </summary>
    [TestClass]
    public class AccountServiceTest
    {
        /// <summary>
        /// The account service mock.
        /// </summary>
        private Mock<IAccountService> accountServiceMock;

        /// <summary>
        /// The account service.
        /// </summary>
        private IAccountService accountService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.accountServiceMock = new Mock<IAccountService>();
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
                Email = "validemail@gmail.com",
            };

            this.accountServiceMock.Setup(x => x.Insert(account)).Returns(true);
            this.accountService = this.accountServiceMock.Object;

            var result = this.accountService.Insert(account);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            this.accountServiceMock.Setup(x => x.GetAll(null, null, null))
                .Returns(
                new List<Account>()
                {
                    new Account
                {
                    PhoneNumber = "0734525427",
                    Email = "validemail@gmail.com",
                },
                });

            this.accountService = this.accountServiceMock.Object;

            var result = this.accountService.GetAll();

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            this.accountServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Account
                {
                    Id = 1,
                    PhoneNumber = "0734525427",
                    Email = "validemail@gmail.com",
                });

            this.accountService = this.accountServiceMock.Object;

            var result = this.accountService.GetByID(1);

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
            this.accountServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Account
                {
                    PhoneNumber = "0734525427",
                    Email = "validemail@gmail.com",
                });

            this.accountService = this.accountServiceMock.Object;

            var modifiedAccount = this.accountService.GetByID(1);
            modifiedAccount.Email = "modifiedemail@gmail.ro";

            this.accountServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = this.accountService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            this.accountServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            this.accountService = this.accountServiceMock.Object;

            var result = this.accountService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}