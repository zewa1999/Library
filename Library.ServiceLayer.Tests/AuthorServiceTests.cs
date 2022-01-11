// <copyright file="AuthorServiceTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Library.DomainLayer;
    using Library.ServiceLayer.IServices;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Defines test class AuthorServiceTests.
    /// </summary>
    [TestClass]
    public class AuthorServiceTests
    {
        /// <summary>
        /// The author service mock.
        /// </summary>
        private Mock<IAuthorService> authorServiceMock;

        /// <summary>
        /// The author service.
        /// </summary>
        private IAuthorService authorService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.authorServiceMock = new Mock<IAuthorService>();
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
            };

            this.authorServiceMock.Setup(x => x.Insert(author)).Returns(true);
            this.authorService = this.authorServiceMock.Object;

            var result = this.authorService.Insert(author);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            this.authorServiceMock.Setup(x => x.GetAll(null, book => book.OrderBy(x => x.Id), null))
                .Returns(
                new List<Author>()
                {
                    new Author
                {
                FirstName = "Marcel",
                LastName = "Dorel",
                },
                });

            this.authorService = this.authorServiceMock.Object;

            var result = this.authorService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            this.authorServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Author
                {
                    Id = 1,
                    FirstName = "Marcel",
                    LastName = "Dorel",
                });

            this.authorService = this.authorServiceMock.Object;

            var result = this.authorService.GetByID(1);

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
            this.authorServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Author
                {
                    FirstName = "Marcel",
                    LastName = "Dorel",
                });

            this.authorService = this.authorServiceMock.Object;

            var modifiedAuthor = this.authorService.GetByID(1);
            modifiedAuthor.FirstName = "Marcel";

            this.authorServiceMock.Setup(x => x.Update(modifiedAuthor)).Returns(true);

            var result = this.authorService.Update(modifiedAuthor);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            this.authorServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            this.authorService = this.authorServiceMock.Object;

            var result = this.authorService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}