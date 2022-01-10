// ***********************************************************************
// Assembly         : Library.ServiceLayer.Tests
// Author           : costa
// Created          : 01-07-2022
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="AuthorServiceTests.cs" company="Library.ServiceLayer.Tests">
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
    /// Defines test class AuthorServiceTests.
    /// </summary>
    [TestClass]
    public class AuthorServiceTests
    {
        /// <summary>
        /// The author service mock
        /// </summary>
        private Mock<IAuthorService> authorServiceMock;

        /// <summary>
        /// The author service
        /// </summary>
        private IAuthorService authorService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            authorServiceMock = new Mock<IAuthorService>();
        }

        /// <summary>
        /// Defines the test method TestInsert.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
                Books = new List<Book>()
            };

            authorServiceMock.Setup(x => x.Insert(author)).Returns(true);
            authorService = authorServiceMock.Object;

            var result = authorService.Insert(author);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            authorServiceMock.Setup(x => x.GetAll(null, book => book.OrderBy(x => x.Id), null))
                .Returns(
                new List<Author>()
                { new Author {
                FirstName = "Marcel",
                LastName = "Dorel",
                Books = new List<Book>()
                }
                });

            authorService = authorServiceMock.Object;

            var result = authorService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            authorServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Author
                {
                    Id = 1,
                    FirstName = "Marcel",
                    LastName = "Dorel",
                    Books = new List<Book>()
                });

            authorService = authorServiceMock.Object;

            var result = authorService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Marcel", result.FirstName);
            Assert.AreEqual("Dorel", result.LastName);
        }

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            authorServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Author
                {
                    FirstName = "Marcel",
                    LastName = "Dorel",
                    Books = new List<Book>()
                });

            authorService = authorServiceMock.Object;

            var modifiedAuthor = authorService.GetByID(1);
            modifiedAuthor.FirstName = "Marcel";

            authorServiceMock.Setup(x => x.Update(modifiedAuthor)).Returns(true);

            var result = authorService.Update(modifiedAuthor);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            authorServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            authorService = authorServiceMock.Object;

            var result = authorService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}