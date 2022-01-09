using Library.DomainLayer;
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
    public class BookServiceTests
    {
        private Mock<IBookService> bookServiceMock;
        private IBookService bookService;

        [TestInitialize]
        public void Initialize()
        {
            bookServiceMock = new Mock<IBookService>();
        }

        [TestMethod]
        public void TestInsert()
        {
            var book = TestUtils.GetBookModel();
            bookServiceMock.Setup(x => x.Insert(book)).Returns(true);
            bookService = bookServiceMock.Object;

            var result = bookService.Insert(book);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            bookServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Book>()
                {TestUtils.GetBookModel()});

            bookService = bookServiceMock.Object;

            var result = bookService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestGetById()
        {
            var book = TestUtils.GetBookModelWithId();
            bookServiceMock.Setup(x => x.GetByID(1))
                .Returns(TestUtils.GetBookModelWithId());

            bookService = bookServiceMock.Object;
            var result = bookService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var book = TestUtils.GetBookModel();

            bookServiceMock.Setup(x => x.GetByID(1))
                .Returns(book);

            bookService = bookServiceMock.Object;

            var modifiedBook = bookService.GetByID(1);
            modifiedBook.Title = "O carte oarecare";

            bookServiceMock.Setup(x => x.Update(modifiedBook)).Returns(true);

            var result = bookService.Update(modifiedBook);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDelete()
        {
            bookServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            bookService = bookServiceMock.Object;

            var result = bookService.DeleteById(1);

            Assert.IsTrue(result);
        }

        public void TestCheckIfDomainExists()
        {
        }

        public void TestBookHasCorrectDomains()
        {
        }

        public void TestGetDomainsWithoutTheFirst()
        {
        }

        public void TestAddAncestorDomains()
        {
        }

        public void TestGetDomainsWithTheFirst()
        {
        }
    }
}