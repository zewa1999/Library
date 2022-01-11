// <copyright file="DomainValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class DomainValidatorTests.
    /// </summary>
    [TestClass]
    public class DomainValidatorTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private DomainValidator validator;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.validator = new ();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNameIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNameIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNameIsEmpty.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNameIsNotEmpty.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNameLenghtIsLessThanOne.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNameIsHigherThanOne.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenChildrenDomainsCollectionIsNull.
        /// </summary>
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