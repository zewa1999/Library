using Library.DomainLayer;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer.Tests
{
    [TestClass]
    public class LibrarianServiceTests
    {
        private Mock<ILibrarianService> librarianServiceMock;
        private ILibrarianService librarianService;

        [TestInitialize]
        public void Initialize()
        {
            librarianServiceMock = new Mock<ILibrarianService>();
        }

        [TestMethod]
        public void TestInsert()
        {
            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com"
            };

            var librarian = new Librarian()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                IsReader = true,
                Account = account
            };

            librarianServiceMock.Setup(x => x.Insert(librarian)).Returns(true);
            librarianService = librarianServiceMock.Object;

            var result = librarianService.Insert(librarian);

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

            var librarian = new Librarian()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                IsReader = true,
                Account = account
            };

            librarianServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Librarian>()
                {librarian});

            librarianService = librarianServiceMock.Object;

            var result = librarianService.GetAll();

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

            var librarian = new Librarian()
            {
                Id = 1,
                LastName = "Gogu",
                FirstName = "Mortu",
                IsReader = true,
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };
            librarianServiceMock.Setup(x => x.GetByID(1))
                .Returns(librarian);

            librarianService = librarianServiceMock.Object;

            var result = librarianService.GetByID(1);

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

            var librarian = new Librarian()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                IsReader = true,
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account
            };

            librarianServiceMock.Setup(x => x.GetByID(1))
                .Returns(librarian);

            librarianService = librarianServiceMock.Object;

            var modifiedAccount = librarianService.GetByID(1);
            modifiedAccount.LastName = "Alexandru";

            librarianServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = librarianService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDelete()
        {
            librarianServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            librarianService = librarianServiceMock.Object;

            var result = librarianService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}