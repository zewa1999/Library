// <copyright file="BaseDomainValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseDomainValidatorTests
    {
        private BaseDomainValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            this.validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameIsNull()
        {
            var model = new Domain()
            {
                Name = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNameIsNotNull()
        {
            var model = new Domain()
            {
                Name = "ceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameIsEmpty()
        {
            var model = new Domain()
            {
                Name = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNameIsNotEmpty()
        {
            var model = new Domain()
            {
                Name = "altceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameLenghtIsLessThanOne()
        {
            var model = new Domain()
            {
                Name = "q",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNameIsHigherThanOne()
        {
            var model = new Domain()
            {
                Name = "qrwer",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenChildrenDomainsCollectionIsNull()
        {
            var model = new Domain()
            {
                ChildrenDomains = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.ChildrenDomains);
        }
    }
}