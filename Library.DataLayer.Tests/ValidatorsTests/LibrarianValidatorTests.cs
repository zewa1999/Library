// <copyright file="LibrarianValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LibrarianValidatorTests
    {
        private LibrarianValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            this.validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameIsNull()
        {
            var model = new Librarian()
            {
                FirstName = null,
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenFirstNameIsNotNull()
        {
            var model = new Librarian()
            {
                FirstName = "ceva",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameIsEmpty()
        {
            var model = new Librarian()
            {
                FirstName = string.Empty,
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenFirstNameIsNotEmpty()
        {
            var model = new Librarian()
            {
                FirstName = "altceva",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameLenghtIsLessThanOne()
        {
            var model = new Librarian()
            {
                FirstName = "q",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenFirstNameIsHigherThanOne()
        {
            var model = new Librarian()
            {
                FirstName = "qrwer",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameIsNotAValidName()
        {
            var model = new Librarian()
            {
                FirstName = "--gds031",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenFirstNameIsAValidName()
        {
            var model = new Librarian()
            {
                FirstName = "Costache",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.FirstName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameIsNull()
        {
            var model = new Librarian()
            {
                LastName = null,
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLastNameIsNotNull()
        {
            var model = new Librarian()
            {
                LastName = "ceva",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameIsEmpty()
        {
            var model = new Librarian()
            {
                LastName = string.Empty,
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLastNameIsNotEmpty()
        {
            var model = new Librarian()
            {
                LastName = "altceva",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameLenghtIsLessThanOne()
        {
            var model = new Librarian()
            {
                LastName = "q",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLastNameIsHigherThanOne()
        {
            var model = new Librarian()
            {
                LastName = "qrwer",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameIsNotAValidName()
        {
            var model = new Librarian()
            {
                LastName = "--gds031",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLastNameIsAValidName()
        {
            var model = new Librarian()
            {
                LastName = "Costache",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LastName);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenAddressIsNull()
        {
            var model = new Librarian()
            {
                Address = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenAddressIsNotNull()
        {
            var model = new Librarian()
            {
                Address = "ceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenAddressIsEmpty()
        {
            var model = new Librarian()
            {
                Address = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenAddressIsNotEmpty()
        {
            var model = new Librarian()
            {
                Address = "altceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenAddressLenghtIsLessThanOne()
        {
            var model = new Librarian()
            {
                Address = "q",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenAddressIsHigherThanTwo()
        {
            var model = new Librarian()
            {
                Address = "qrwer",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenIsReaderIsNull()
        {
            var model = new Librarian()
            {
                IsReader = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.IsReader);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenIsReaderIsNotNull()
        {
            var model = new Librarian()
            {
                IsReader = true,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.IsReader);
        }
    }
}