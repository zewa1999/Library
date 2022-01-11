// ***********************************************************************
// Assembly         : Library.DomainLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="DomainTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Tests.PersonTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class DomainTests.
    /// </summary>
    [TestClass]
    public class DomainTests
    {
        /// <summary>
        /// The domain.
        /// </summary>
        private Domain domain;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.domain = new ();
        }

        /// <summary>
        /// Defines the test method DomainNameShouldNotContainDigits.
        /// </summary>
        [TestMethod]
        public void DomainNameShouldNotContainDigits()
        {
            this.domain.Name = "Informatica 221";

            var flag = this.domain.Name.All(char.IsDigit);

            Assert.IsFalse(flag);
        }

        /// <summary>
        /// Defines the test method DomainNameShouldBeCapitalized.
        /// </summary>
        [TestMethod]
        public void DomainNameShouldBeCapitalized()
        {
            this.domain.Name = "Informatica";

            var flag = char.IsUpper(this.domain.Name[0]);
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Defines the test method DomainParentShouldNotBeNull.
        /// </summary>
        [TestMethod]
        public void DomainParentShouldNotBeNull()
        {
            var parentDomain = new Domain();
            this.domain.ParentDomain = parentDomain;

            Assert.IsNotNull(this.domain.ParentDomain);
        }

        /// <summary>
        /// Defines the test method DomainChildrensShouldNotBeNull.
        /// </summary>
        [TestMethod]
        public void DomainChildrensShouldNotBeNull()
        {
            var childrens = new List<Domain>();
            this.domain.ChildrenDomains = childrens;

            Assert.IsNotNull(this.domain.ChildrenDomains);
        }
    }
}