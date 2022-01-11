// <copyright file="DomainTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer.Tests.PersonTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class DomainTests
    {
        private Domain domain;

        [TestInitialize]
        public void Initialize()
        {
            this.domain = new();
        }

        [TestMethod]
        public void DomainNameShouldNotContainDigits()
        {
            this.domain.Name = "Informatica 221";

            var flag = this.domain.Name.All(char.IsDigit);

            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void DomainNameShouldBeCapitalized()
        {
            this.domain.Name = "Informatica";

            var flag = char.IsUpper(this.domain.Name[0]);
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void DomainParentShouldNotBeNull()
        {
            var parentDomain = new Domain();
            this.domain.ParentDomain = parentDomain;

            Assert.IsNotNull(this.domain.ParentDomain);
        }

        [TestMethod]
        public void DomainChildrensShouldNotBeNull()
        {
            var childrens = new List<Domain>();
            this.domain.ChildrenDomains = childrens;

            Assert.IsNotNull(this.domain.ChildrenDomains);
        }
    }
}