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
    public class BorrowerServiceTests
    {
        private IBorrowerService service;

        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            service = Injector.Create<IBorrowerService>();
        }

        [TestMethod]
        public void TestInsert()
        {
        }

        public void TestUpdate()
        {
        }

        public void TestDelete()
        {
        }

        public void TestGetAll()
        {
        }

        public void TestGetById()
        {
        }
    }
}