// ***********************************************************************
// Assembly         : Library.DataLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="AccountValidatorTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class AccountValidatorTests.
    /// </summary>
    [TestClass]
    public class AccountValidatorTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private AccountValidator validator;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.validator = new ();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPhoneNumberIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberIsNull()
        {
            var model = new Account()
            {
                PhoneNumber = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPhoneNumberIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberIsNotNull()
        {
            var model = new Account()
            {
                PhoneNumber = "0755234562",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPhoneNumberIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberIsEmpty()
        {
            var model = new Account()
            {
                PhoneNumber = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPhoneNumberIsNotEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberIsNotEmpty()
        {
            var model = new Account()
            {
                PhoneNumber = "0723456729",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPhoneNumberHasMoreThan10Digits.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberHasMoreThan10Digits()
        {
            var model = new Account()
            {
                PhoneNumber = "12345678901231234",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPhoneNumberDoesNotHaveMoreThan10Digits.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberDoesNotHaveMoreThan10Digits()
        {
            var model = new Account()
            {
                PhoneNumber = "0723456739",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPhoneNumberContainsLetters.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberContainsLetters()
        {
            var model = new Account()
            {
                PhoneNumber = "1234567890dasda",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPhoneNumberDoesNotContainLetters.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberDoesNotContainLetters()
        {
            var model = new Account()
            {
                PhoneNumber = "0723455672",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPhoneNumberIsValid.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberIsValid()
        {
            var model = new Account()
            {
                PhoneNumber = "0755234123",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEmailDoesNotContainProperCharacters1.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEmailDoesNotContainProperCharacters1()
        {
            var model = new Account()
            {
                Email = "invalidemail",
                PhoneNumber = "0755234123",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Email);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEmailDoesNotContainProperCharacters2.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEmailDoesNotContainProperCharacters2()
        {
            var model = new Account()
            {
                Email = "invalidemail@",
                PhoneNumber = "0755234123",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Email);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEmailDoesNotContainProperCharacters3.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEmailDoesNotContainProperCharacters3()
        {
            var model = new Account()
            {
                Email = "invalidemail.mail",
                PhoneNumber = "0755234123",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Email);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenEmailIsValid.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenEmailIsValid()
        {
            var model = new Account()
            {
                Email = "validemail@mail.com",
                PhoneNumber = "0755234123",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}