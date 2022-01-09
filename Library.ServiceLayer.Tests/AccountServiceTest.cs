using Library.DataLayer.DataMapper;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Library.ServiceLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentValidation.Results;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Library.ServiceLayer.Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        private Mock<IAccountService> accountServiceMock;
        private IAccountService accountService;

        [TestInitialize]
        public void Initialize()
        {
            accountServiceMock = new Mock<IAccountService>();
        }

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