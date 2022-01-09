using FluentValidation.TestHelper;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Library.DataLayer.Tests.ValidatorsTests
{
    [TestClass]
    public class DomainValidatorTests
    {
        private DomainValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameIsNull()
        {
            var model = new Domain()
            {
                Name = null,
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNameIsNotNull()
        {
            var model = new Domain()
            {
                Name = "ceva",
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameIsEmpty()
        {
            var model = new Domain()
            {
                Name = "",
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNameIsNotEmpty()
        {
            var model = new Domain()
            {
                Name = "altceva"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameLenghtIsLessThanOne()
        {
            var model = new Domain()
            {
                Name = "q"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNameIsHigherThanOne()
        {
            var model = new Domain()
            {
                Name = "qrwer"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Name);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenChildrenDomainsCollectionIsNull()
        {
            var model = new Domain()
            {
                ChildrenDomains = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.ChildrenDomains);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenChildrenDomainsCollectionIsEmpty()
        {
            var model = new Domain()
            {
                ChildrenDomains = new List<Domain>()
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.ChildrenDomains);
        }
    }
}