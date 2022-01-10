﻿// ***********************************************************************
// Assembly         : Library.ServiceLayer.Tests
// Author           : costa
// Created          : 01-07-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="BorrowServiceTests.cs" company="Library.ServiceLayer.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.ServiceLayer.Tests
{
    /// <summary>
    /// Defines test class BorrowServiceTests.
    /// </summary>
    [TestClass]
    public class BorrowServiceTests
    {
        /// <summary>
        /// The borrow service mock
        /// </summary>
        private Mock<IBorrowService> borrowServiceMock;

        /// <summary>
        /// The borrow service
        /// </summary>
        private IBorrowService borrowService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            borrowServiceMock = new Mock<IBorrowService>();
        }

        /// <summary>
        /// Defines the test method TestInsert.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            var borrow = TestUtils.GetBorrowModel();
            borrowServiceMock.Setup(x => x.Insert(borrow)).Returns(true);
            borrowService = borrowServiceMock.Object;

            var result = borrowService.Insert(borrow);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            borrowServiceMock.Setup(x => x.GetAll(null, book => book.OrderBy(x => x.Id), null))
                .Returns(
                new List<Borrow>()
                {TestUtils.GetBorrowModel()});

            borrowService = borrowServiceMock.Object;

            var result = borrowService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
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

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
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

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            borrowServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            borrowService = borrowServiceMock.Object;

            var result = borrowService.DeleteById(1);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the get number of borrowed books.
        /// </summary>
        public void TestGetNumberOfBorrowedBooks()
        {
        }

        /// <summary>
        /// Tests the get maximum period of time for borrowing.
        /// </summary>
        public void TestGetMaximumPeriodOfTimeForBorrowing()
        {
        }

        /// <summary>
        /// Tests the check lim.
        /// </summary>
        public void TestCheckLIM()
        {
        }

        /// <summary>
        /// Tests the check same book borrowing in a delta time.
        /// </summary>
        public void TestCheckSameBookBorrowingInADeltaTime()
        {
        }

        /// <summary>
        /// Tests the check no of books of the same domain.
        /// </summary>
        public void TestCheckNoOfBooksOfTheSameDomain()
        {
        }

        /// <summary>
        /// Tests the check if books are borrowable.
        /// </summary>
        public void TestCheckIfBooksAreBorrowable()
        {
        }

        /// <summary>
        /// Tests the can borrow book.
        /// </summary>
        public void TestCanBorrowBook()
        {
        }

        /// <summary>
        /// Tests the check distinct categories.
        /// </summary>
        public void TestCheckDistinctCategories()
        {
        }

        /// <summary>
        /// Tests the get books between past months and present.
        /// </summary>
        public void TestGetBooksBetweenPastMonthsAndPresent()
        {
        }
    }
}