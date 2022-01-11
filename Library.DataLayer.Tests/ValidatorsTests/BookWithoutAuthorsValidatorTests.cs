// <copyright file="BookWithoutAuthorsValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using System.Collections.Generic;
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class BookWithoutAuthorsValidatorTests.
    /// </summary>
    [TestClass]
    public class BookWithoutAuthorsValidatorTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private BookWithoutAuthorsValidator validator;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.validator = new ();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTitleIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTitleIsNull()
        {
            var model = new Book()
            {
                Title = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTitleIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsNotNull()
        {
            var model = new Book()
            {
                Title = "ceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTitleIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTitleIsEmpty()
        {
            var model = new Book()
            {
                Title = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTitleIsNotEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsNotEmpty()
        {
            var model = new Book()
            {
                Title = "altceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTitleLenghtIsLessThanOne.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTitleLenghtIsLessThanOne()
        {
            var model = new Book()
            {
                Title = "q",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTitleIsHigherThanOne.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsHigherThanOne()
        {
            var model = new Book()
            {
                Title = "qrwer",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTitleIsNotAValidName.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTitleIsNotAValidName()
        {
            var model = new Book()
            {
                Title = "--gds031",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTitleIsAValidName.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsAValidName()
        {
            var model = new Book()
            {
                Title = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTypeIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTypeIsNull()
        {
            var model = new Book()
            {
                Type = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTypeIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsNotNull()
        {
            var model = new Book()
            {
                Type = "ceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTypeIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTypeIsEmpty()
        {
            var model = new Book()
            {
                Type = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTypeIsNotEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsNotEmpty()
        {
            var model = new Book()
            {
                Type = "altceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTypeLenghtIsLessThanOne.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTypeLenghtIsLessThanOne()
        {
            var model = new Book()
            {
                Type = "q",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTypeIsHigherThanOne.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsHigherThanOne()
        {
            var model = new Book()
            {
                Type = "qrwer",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenTypeIsNotAValidName.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenTypeIsNotAValidName()
        {
            var model = new Book()
            {
                Type = "--gds031",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenTypeIsAValidName.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsAValidName()
        {
            var model = new Book()
            {
                Type = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenIsBorrowedIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenIsBorrowedIsNull()
        {
            var model = new Book()
            {
                IsBorrowed = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.IsBorrowed);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenIsBorrowedIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenIsBorrowedIsNotNull()
        {
            var model = new Book()
            {
                IsBorrowed = true,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.IsBorrowed);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEditionsCollectionIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEditionsCollectionIsNull()
        {
            var model = new Book()
            {
                Editions = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Editions);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEditionsCollectionIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEditionsCollectionIsEmpty()
        {
            var model = new Book()
            {
                Editions = new List<Edition>(),
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Editions);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenDomainsCollectionIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenDomainsCollectionIsNull()
        {
            var model = new Book()
            {
                Domains = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Domains);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenDomainsCollectionIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenDomainsCollectionIsEmpty()
        {
            var model = new Book()
            {
                Domains = new List<Domain>(),
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Domains);
        }
    }
}