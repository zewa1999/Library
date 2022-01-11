﻿// <copyright file="AuthorValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuthorValidatorTests
    {
        private AuthorValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            this.validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameIsNull()
        {
            var model = new Author()
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
            var model = new Author()
            {
                FirstName = "ceva",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameIsEmpty()
        {
            var model = new Author()
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
            var model = new Author()
            {
                FirstName = "altceva",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameLenghtIsLessThanOne()
        {
            var model = new Author()
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
            var model = new Author()
            {
                FirstName = "qrwer",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenFirstNameIsNotAValidName()
        {
            var model = new Author()
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
            var model = new Author()
            {
                FirstName = "Costache",
                LastName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameIsNull()
        {
            var model = new Author()
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
            var model = new Author()
            {
                LastName = "ceva",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameIsEmpty()
        {
            var model = new Author()
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
            var model = new Author()
            {
                LastName = "altceva",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameLenghtIsLessThanOne()
        {
            var model = new Author()
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
            var model = new Author()
            {
                LastName = "qrwer",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLastNameIsNotAValidName()
        {
            var model = new Author()
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
            var model = new Author()
            {
                LastName = "Costache",
                FirstName = "Costache",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}