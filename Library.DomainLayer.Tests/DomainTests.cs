using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Library.DomainLayer.Tests.PersonTests
{
    [TestClass]
    public class DomainTests
    {
        private Domain domain;

        [TestInitialize]
        public void Initialize()
        {
            domain = new();
        }

        [TestMethod]
        public void DomainNameShouldNotContainDigits()
        {
            domain.Name = "Informatica 221";

            var flag = domain.Name.All(char.IsDigit);

            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void DomainNameShouldBeCapitalized()
        {
            domain.Name = "Informatica";

            var flag = char.IsUpper(domain.Name[0]);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void DomainParentShouldNotBeNull()
        {
            var parentDomain = new Domain();
            domain.ParentDomain = parentDomain;

            Assert.IsNotNull(domain.ParentDomain);
        }

        [TestMethod]
        public void DomainChildrensShouldNotBeNull()
        {
            var childrens = new List<Domain>();
            domain.ChildrenDomains = childrens;

            Assert.IsNotNull(domain.ChildrenDomains);
        }
    }
}