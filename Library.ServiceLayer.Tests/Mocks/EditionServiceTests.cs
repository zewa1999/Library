// <copyright file="EditionServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines test class EditionServiceTests.
    /// </summary>
    [TestClass]
    public class EditionServiceTests
    {
        /// <summary>
        /// The edition service mock.
        /// </summary>
        private Mock<IEditionService> editionServiceMock;

        /// <summary>
        /// The edition service.
        /// </summary>
        private IEditionService editionService;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.editionServiceMock = new Mock<IEditionService>();
        }

        /// <summary>
        /// Defines the test method TestInsert.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            var edition = new Edition()
            {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 1,
            };

            this.editionServiceMock.Setup(x => x.Insert(edition)).Returns(true);
            this.editionService = this.editionServiceMock.Object;

            var result = this.editionService.Insert(edition);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestGetAll.
        /// </summary>
        [TestMethod]
        public void TestGetAll()
        {
            this.editionServiceMock.Setup(x => x.GetAll(null, null, null))
                .Returns(
                new List<Edition>()
                {
                    new Edition
                {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 1,
                },
                });

            this.editionService = this.editionServiceMock.Object;

            var result = this.editionService.GetAll();

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Defines the test method TestGetById.
        /// </summary>
        [TestMethod]
        public void TestGetById()
        {
            this.editionServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Edition
                {
                    Id = 1,
                    Publisher = "Cartea studentilor saraci",
                    Year = "1999",
                    EditionNumber = int.MaxValue,
                    NumberOfPages = 1,
                });

            this.editionService = this.editionServiceMock.Object;

            var result = this.editionService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.NumberOfPages);
            Assert.AreEqual("Cartea studentilor saraci", result.Publisher);
        }

        /// <summary>
        /// Defines the test method TestUpdate.
        /// </summary>
        [TestMethod]
        public void TestUpdate()
        {
            this.editionServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Edition
                {
                    Publisher = "Cartea studentilor saraci",
                    Year = "1999",
                    EditionNumber = int.MaxValue,
                    NumberOfPages = 1,
                });

            this.editionService = this.editionServiceMock.Object;

            var modifiedAccount = this.editionService.GetByID(1);
            modifiedAccount.EditionNumber = 7;

            this.editionServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = this.editionService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Defines the test method TestDelete.
        /// </summary>
        [TestMethod]
        public void TestDelete()
        {
            this.editionServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            this.editionService = this.editionServiceMock.Object;

            var result = this.editionService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}