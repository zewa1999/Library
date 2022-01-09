﻿using Library.DomainLayer;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer.Tests
{
    [TestClass]
    public class BorrowerServiceTests
    {
        private Mock<IBorrowerService> borrowerServiceMock;
        private IBorrowerService borrowerService;

        [TestInitialize]
        public void Initialize()
        {
            borrowerServiceMock = new Mock<IBorrowerService>();
        }

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