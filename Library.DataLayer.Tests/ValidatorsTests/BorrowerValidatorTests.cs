// <copyright file="BorrowerValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BorrowerValidatorTests
    {
        private BorrowerValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            this.validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameIsNull()
        {
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
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
            var model = new Borrower()
            {
                Address = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenAddressIsNotNull()
        {
            var model = new Borrower()
            {
                Address = "ceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenAddressIsEmpty()
        {
            var model = new Borrower()
            {
                Address = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenAddressIsNotEmpty()
        {
            var model = new Borrower()
            {
                Address = "altceva",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenAddressLenghtIsLessThanOne()
        {
            var model = new Borrower()
            {
                Address = "q",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Address);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenAddressIsHigherThanTwo()
        {
            var model = new Borrower()
            {
                Address = "qrwer",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Address);
        }

        // de facut si pentru colectii
    }
}