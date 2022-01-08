using Library.DataLayer.DataMapper;
using Library.DomainLayer.Person;
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
    public class AccountServiceTest
    {
        private IAccountService service;
        private Account model;

        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            service = Injector.Create<IAccountService>();
        }

        [TestMethod]
        public void TestInsert()
        {
            model = new()
            {
                PhoneNumber = "0734525427",
                Email = "validjhvjhvfhcdg@gmail.com"
            };
            //var validationResult = service.Insert(model);

            //if (!validationResult.IsValid)
            //{
            //    Assert.IsTrue(false);
            //}

            if (!service.Insert(model).IsValid)
            {
                Assert.IsTrue(false);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestGetAll()
        {
            var cacat = service.GetAll();
            Assert.IsNotNull(service.GetAll());
        }

        [TestMethod]
        public void TestGetById()
        {
            object id = model.Id;
            if (service.GetByID(id) == null)
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var accountModel = service.GetByID(8);
            accountModel.Email = "gigimuschi@gmail.com";
            var validationResult = service.Update(accountModel);
            if (!validationResult.IsValid)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            object id = 1;
            if (service.DeleteById(id))
            {
                Assert.IsTrue(true);
            }
        }
    }
}