using FluentValidation.TestHelper;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Library.DataLayer.Tests.ValidatorsTests
{
    [TestClass]
    public class BookValidatorTests
    {
        private BookValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTitleIsNull()
        {
            var model = new Book()
            {
                Title = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsNotNull()
        {
            var model = new Book()
            {
                Title = "ceva"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTitleIsEmpty()
        {
            var model = new Book()
            {
                Title = ""
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsNotEmpty()
        {
            var model = new Book()
            {
                Title = "altceva"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTitleLenghtIsLessThanOne()
        {
            var model = new Book()
            {
                Title = "q"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsHigherThanOne()
        {
            var model = new Book()
            {
                Title = "qrwer",
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTitleIsNotAValidName()
        {
            var model = new Book()
            {
                Title = "--gds031"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTitleIsAValidName()
        {
            var model = new Book()
            {
                Title = "Costache"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Title);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTypeIsNull()
        {
            var model = new Book()
            {
                Type = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsNotNull()
        {
            var model = new Book()
            {
                Type = "ceva"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTypeIsEmpty()
        {
            var model = new Book()
            {
                Type = ""
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsNotEmpty()
        {
            var model = new Book()
            {
                Type = "altceva"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTypeLenghtIsLessThanOne()
        {
            var model = new Book()
            {
                Type = "q"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsHigherThanOne()
        {
            var model = new Book()
            {
                Type = "qrwer",
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenTypeIsNotAValidName()
        {
            var model = new Book()
            {
                Type = "--gds031"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenTypeIsAValidName()
        {
            var model = new Book()
            {
                Type = "Costache"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Type);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenIsBorrowedIsNull()
        {
            var model = new Book()
            {
                IsBorrowed = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.IsBorrowed);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenIsBorrowedIsNotNull()
        {
            var model = new Book()
            {
                IsBorrowed = true
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.IsBorrowed);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenAuthorCollectionIsNull()
        {
            var model = new Book()
            {
                Authors = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Authors);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenAuthorCollectionIsEmpty()
        {
            var model = new Book()
            {
                Authors = new List<Author>()
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Authors);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEditionsCollectionIsNull()
        {
            var model = new Book()
            {
                Editions = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Editions);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEditionsCollectionIsEmpty()
        {
            var model = new Book()
            {
                Editions = new List<Edition>()
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Editions);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDomainsCollectionIsNull()
        {
            var model = new Book()
            {
                Domains = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Domains);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDomainsCollectionIsEmpty()
        {
            var model = new Book()
            {
                Domains = new List<Domain>()
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Domains);
        }
    }
}