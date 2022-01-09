using Library.DomainLayer;
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
    public class BorrowServiceTests
    {
        private Mock<IBorrowService> borrowServiceMock;
        private IBorrowService borrowService;

        [TestInitialize]
        public void Initialize()
        {
            borrowServiceMock = new Mock<IBorrowService>();
        }

        [TestMethod]
        public void TestInsert()
        {
            var borrow = TestUtils.GetBorrowModel();
            borrowServiceMock.Setup(x => x.Insert(borrow)).Returns(true);
            borrowService = borrowServiceMock.Object;

            var result = borrowService.Insert(borrow);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            borrowServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Borrow>()
                {TestUtils.GetBorrowModel()});

            borrowService = borrowServiceMock.Object;

            var result = borrowService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestGetById()
        {
            var borrow = TestUtils.GetBorrowModelWithId();
            borrowServiceMock.Setup(x => x.GetByID(1))
                .Returns(TestUtils.GetBorrowModelWithId());

            borrowService = borrowServiceMock.Object;
            var result = borrowService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var borrow = TestUtils.GetBorrowModel();

            borrowServiceMock.Setup(x => x.GetByID(1))
                .Returns(borrow);

            borrowService = borrowServiceMock.Object;

            var modifiedBorrow = borrowService.GetByID(1);
            modifiedBorrow.EndDate = DateTime.Now;

            borrowServiceMock.Setup(x => x.Update(modifiedBorrow)).Returns(true);

            var result = borrowService.Update(modifiedBorrow);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDelete()
        {
            borrowServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            borrowService = borrowServiceMock.Object;

            var result = borrowService.DeleteById(1);

            Assert.IsTrue(result);
        }

        public void TestGetNumberOfBorrowedBooks()
        {
        }

        public void TestGetMaximumPeriodOfTimeForBorrowing()
        {
        }

        public void TestCheckLIM()
        {
        }

        public void TestCheckSameBookBorrowingInADeltaTime()
        {
        }

        public void TestCheckNoOfBooksOfTheSameDomain()
        {
        }

        public void TestCheckIfBooksAreBorrowable()
        {
        }

        public void TestCanBorrowBook()
        {
        }

        public void TestCheckDistinctCategories()
        {
        }

        public void TestGetBooksBetweenPastMonthsAndPresent()
        {
        }
    }
}