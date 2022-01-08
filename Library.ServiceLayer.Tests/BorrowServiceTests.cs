using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private IBorrowService service;

        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            service = Injector.Create<IBorrowService>();
        }

        [TestMethod]
        public void TestInsert()
        {
        }

        public void TestUpdate()
        {
        }

        public void TestDelete()
        {
        }

        public void TestGetAll()
        {
        }

        public void TestGetById()
        {
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