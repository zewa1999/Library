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
    public class EditionServiceTests
    {
        private Mock<IEditionService> editionServiceMock;
        private IEditionService editionService;

        [TestInitialize]
        public void Initialize()
        {
            editionServiceMock = new Mock<IEditionService>();
        }

        [TestMethod]
        public void TestInsert()
        {
            var edition = new Edition()
            {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 1
            };

            editionServiceMock.Setup(x => x.Insert(edition)).Returns(true);
            editionService = editionServiceMock.Object;

            var result = editionService.Insert(edition);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            editionServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Edition>()
                { new Edition {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 1}
                });

            editionService = editionServiceMock.Object;

            var result = editionService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestGetById()
        {
            editionServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Edition
                {
                    Id = 1,
                    Publisher = "Cartea studentilor saraci",
                    Year = "1999",
                    EditionNumber = int.MaxValue,
                    NumberOfPages = 1
                });

            editionService = editionServiceMock.Object;

            var result = editionService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.NumberOfPages);
            Assert.AreEqual("Cartea studentilor saraci", result.Publisher);
            // etc
        }

        [TestMethod]
        public void TestUpdate()
        {
            editionServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Edition
                {
                    Publisher = "Cartea studentilor saraci",
                    Year = "1999",
                    EditionNumber = int.MaxValue,
                    NumberOfPages = 1
                });

            editionService = editionServiceMock.Object;

            var modifiedAccount = editionService.GetByID(1);
            modifiedAccount.EditionNumber = 7;

            editionServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = editionService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDelete()
        {
            editionServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            editionService = editionServiceMock.Object;

            var result = editionService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}