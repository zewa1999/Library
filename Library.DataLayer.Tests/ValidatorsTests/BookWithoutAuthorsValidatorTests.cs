// <copyright file="BookWithoutAuthorsValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class BookWithoutAuthorsValidatorTests
    {
        private BookWithoutAuthorsValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            this.validator = new();
        }

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