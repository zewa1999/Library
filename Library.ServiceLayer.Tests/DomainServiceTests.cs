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
    public class DomainServiceTests
    {
        private Mock<IDomainService> domainServiceMock;
        private IDomainService domainService;

        [TestInitialize]
        public void Initialize()
        {
            domainServiceMock = new Mock<IDomainService>();
        }

        [TestMethod]
        public void TestInsert()
        {
            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };

            domainServiceMock.Setup(x => x.Insert(domain)).Returns(true);
            domainService = domainServiceMock.Object;

            var result = domainService.Insert(domain);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };

            domainServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Domain>()
                {domain});

            domainService = domainServiceMock.Object;

            var result = domainService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestGetById()
        {
            var domain = new Domain()
            {
                Id = 1,
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };
            domainServiceMock.Setup(x => x.GetByID(1))
                .Returns(domain);

            domainService = domainServiceMock.Object;

            var result = domainService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Stiinta", result.Name);
            Assert.IsNull(result.ParentDomain);
            // etc
        }

        [TestMethod]
        public void TestUpdate()
        {
            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>()
            };

            domainServiceMock.Setup(x => x.GetByID(1))
                .Returns(domain);

            domainService = domainServiceMock.Object;

            var modifiedAccount = domainService.GetByID(1);
            modifiedAccount.Name = "Filozofie";

            domainServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = domainService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDelete()
        {
            domainServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            domainService = domainServiceMock.Object;

            var result = domainService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}