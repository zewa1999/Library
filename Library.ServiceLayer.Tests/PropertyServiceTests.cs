using Library.DomainLayer;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ServiceLayer.Tests
{
    [TestClass]
    public class PropertyServiceTests
    {
        private Mock<IPropertiesService> propertiesServiceMock;
        private IPropertiesService propertiesService;

        [TestInitialize]
        public void Initialize()
        {
            propertiesServiceMock = new Mock<IPropertiesService>();
        }

        [TestMethod]
        public void TestInsert()
        {
            var properties = new Properties()
            {
                Domenii = 2,
                NumarMaximCarti = 3,
                L = 2,
                NrMaximCartiImprumutate = 3,
                NrMaximCartiImprumutateAcelasiDomeniu = 2,
                LimitaMaximaImprumut = 2,
                Delta = 3,
                NumarCartiImprumutateZilnic = 4,
                Persimp = 3
            };

            propertiesServiceMock.Setup(x => x.Insert(properties)).Returns(true);
            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.Insert(properties);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            propertiesServiceMock.Setup(x => x.GetAll())
                .Returns(
                new List<Properties>()
                { new Properties {
                    Domenii = 2,
                NumarMaximCarti = 3,
                L = 2,
                NrMaximCartiImprumutate = 3,
                NrMaximCartiImprumutateAcelasiDomeniu = 2,
                LimitaMaximaImprumut = 2,
                Delta = 3,
                NumarCartiImprumutateZilnic = 4,
                Persimp = 3}
                });

            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestGetById()
        {
            propertiesServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Properties
                {
                    Id = 1,
                    Domenii = 2,
                    NumarMaximCarti = 3,
                    L = 2,
                    NrMaximCartiImprumutate = 3,
                    NrMaximCartiImprumutateAcelasiDomeniu = 2,
                    LimitaMaximaImprumut = 2,
                    Delta = 3,
                    NumarCartiImprumutateZilnic = 4,
                    Persimp = 3
                });

            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.GetByID(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(2, result.Domenii);
            Assert.AreEqual(3, result.NumarMaximCarti);
            // etc
        }

        [TestMethod]
        public void TestUpdate()
        {
            propertiesServiceMock.Setup(x => x.GetByID(1))
                .Returns(new Properties
                {
                    Domenii = 2,
                    NumarMaximCarti = 3,
                    L = 2,
                    NrMaximCartiImprumutate = 3,
                    NrMaximCartiImprumutateAcelasiDomeniu = 2,
                    LimitaMaximaImprumut = 2,
                    Delta = 3,
                    NumarCartiImprumutateZilnic = 4,
                    Persimp = 3
                });

            propertiesService = propertiesServiceMock.Object;

            var modifiedAccount = propertiesService.GetByID(1);
            modifiedAccount.Domenii = 7;

            propertiesServiceMock.Setup(x => x.Update(modifiedAccount)).Returns(true);

            var result = propertiesService.Update(modifiedAccount);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDelete()
        {
            propertiesServiceMock.Setup(x => x.DeleteById(1)).Returns(true);
            propertiesService = propertiesServiceMock.Object;

            var result = propertiesService.DeleteById(1);

            Assert.IsTrue(result);
        }
    }
}