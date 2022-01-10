// ***********************************************************************
// Assembly         : Library.ServiceLayer.Tests
// Author           : costa
// Created          : 01-07-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="BookServiceTests.cs" company="Library.ServiceLayer.Tests">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Library.ServiceLayer.Tests
{
    /// <summary>
    /// Defines test class BookServiceTests.
    /// </summary>
    [TestClass]
    public class BookServiceTests
    {
        /// <summary>
        /// The book service mock
        /// </summary>
        private Mock<IBookService> bookServiceMock;

        /// <summary>
        /// The book service
        /// </summary>
        private IBookService bookService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            bookServiceMock = new Mock<IBookService>();
        }

        /// <summary>
        /// Defines the test method TestInsert.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            var book = TestUtils.GetBookModel();
            bookServiceMock.Setup(x => x.Insert(book)).Returns(true);
            bookService = bookServiceMock.Object;

            var result = bookService.Insert(book);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            bookServiceMock.Setup(x => x.GetAll(null, book => book.OrderBy(x => x.Id), null))
                .Returns(
                new List<Book>()
                {TestUtils.GetBookModel()});

            bookService = bookServiceMock.Object;

            var result = bookService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
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

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
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

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            bookServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            bookService = bookServiceMock.Object;

            var result = bookService.DeleteById(1);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the check if domain exists.
        /// </summary>
        public void TestCheckIfDomainExists()
        {
        }

        /// <summary>
        /// Tests the book has correct domains.
        /// </summary>
        public void TestBookHasCorrectDomains()
        {
        }

        /// <summary>
        /// Tests the get domains without the first.
        /// </summary>
        public void TestGetDomainsWithoutTheFirst()
        {
        }

        /// <summary>
        /// Tests the add ancestor domains.
        /// </summary>
        public void TestAddAncestorDomains()
        {
        }

        /// <summary>
        /// Tests the get domains with the first.
        /// </summary>
        public void TestGetDomainsWithTheFirst()
        {
        }
    }
}