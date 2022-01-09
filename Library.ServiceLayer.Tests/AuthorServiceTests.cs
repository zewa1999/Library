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
    public class AuthorServiceTests
    {
        private Mock<IAuthorService> authorServiceMock;
        private IAuthorService authorService;

        [TestInitialize]
        public void Initialize()
        {
            authorServiceMock = new Mock<IAuthorService>();
        }

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

        [TestMethod]
        public void TestGetAll()
        {
            authorServiceMock.Setup(x => x.GetAll())
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