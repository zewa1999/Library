using FluentValidation.TestHelper;
using Library.DataLayer.Validators;
using Library.DomainLayer.Person;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.DataLayer.Tests.ValidatorsTests
{
    [TestClass]
    public class AccountValidatorTests
    {
        private AccountValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberIsNull()
        {
            var model = new Account()
            {
                PhoneNumber = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberIsNotNull()
        {
            var model = new Account()
            {
                PhoneNumber = "0755234562"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberIsEmpty()
        {
            var model = new Account()
            {
                PhoneNumber = ""
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberIsNotEmpty()
        {
            var model = new Account()
            {
                PhoneNumber = "0723456729"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberHasMoreThan10Digits()
        {
            var model = new Account()
            {
                PhoneNumber = "12345678901231234"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberDoesNotHaveMoreThan10Digits()
        {
            var model = new Account()
            {
                PhoneNumber = "0723456739"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPhoneNumberContainsLetters()
        {
            var model = new Account()
            {
                PhoneNumber = "1234567890dasda"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PhoneNumber);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberDoesNotContainLetters()
        {
            var model = new Account()
            {
                PhoneNumber = "0723455672"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPhoneNumberIsValid()
        {
            var model = new Account()
            {
                PhoneNumber = "0755234123"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEmailDoesNotContainProperCharacters1()
        {
            var model = new Account()
            {
                Email = "invalidemail",
                PhoneNumber = "0755234123"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Email);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEmailDoesNotContainProperCharacters2()
        {
            var model = new Account()
            {
                Email = "invalidemail@",
                PhoneNumber = "0755234123"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Email);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEmailDoesNotContainProperCharacters3()
        {
            var model = new Account()
            {
                Email = "invalidemail.mail",
                PhoneNumber = "0755234123"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Email);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenEmailIsValid()
        {
            var model = new Account()
            {
                Email = "validemail@mail.com",
                PhoneNumber = "0755234123"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
