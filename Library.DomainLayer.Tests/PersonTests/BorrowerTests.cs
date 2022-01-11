// ***********************************************************************
// Assembly         : Library.DomainLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="BorrowerTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Tests
{
    using System.Linq;
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class BorrowerTests.
    /// </summary>
    [TestClass]
    public class BorrowerTests
    {
        /// <summary>
        /// The borrower.
        /// </summary>
        private Borrower borrower;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.borrower = new ();
        }

        /// <summary>
        /// Defines the test method BorrowerIdShouldBeValid.
        /// </summary>
        [TestMethod]
        public void BorrowerIdShouldBeValid()
        {
            this.borrower.Id = 1;
            Assert.AreEqual(1, this.borrower.Id);
        }

        /// <summary>
        /// Defines the test method LastNameShouldBeValid.
        /// </summary>
        [TestMethod]
        public void LastNameShouldBeValid()
        {
            this.borrower.LastName = "Costache";
            bool isIntString = this.borrower.LastName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        /// <summary>
        /// Defines the test method LastNameShouldBeInvalid.
        /// </summary>
        [TestMethod]
        public void LastNameShouldBeInvalid()
        {
            this.borrower.LastName = "Costache123";
            bool isIntString = this.borrower.LastName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        /// <summary>
        /// Defines the test method FirstNameShouldBeValid.
        /// </summary>
        [TestMethod]
        public void FirstNameShouldBeValid()
        {
            this.borrower.FirstName = "Stelian";
            bool isIntString = this.borrower.FirstName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        /// <summary>
        /// Defines the test method FirstNameShouldBeInvalid.
        /// </summary>
        [TestMethod]
        public void FirstNameShouldBeInvalid()
        {
            this.borrower.FirstName = "1223Andrei";
            bool isIntString = this.borrower.FirstName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeValidIfContainsComma.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeValidIfContainsComma()
        {
            this.borrower.Address = "Street Strada Mea, Apartment Building 16, Brasov, Number 37, Romania";
            bool flag1 = this.borrower.Address.Contains(',');
            Assert.IsTrue(flag1);
            Assert.IsTrue(flag1);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfStreetDoesNotExist.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfStreetDoesNotExist()
        {
            this.borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag3 = this.borrower.Address.Contains("Street");
            Assert.IsFalse(flag3);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfNumberDoesNotExist.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfNumberDoesNotExist()
        {
            this.borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.borrower.Address.Contains("Number");
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfApartmentBuildingDoesNotExist.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfApartmentBuildingDoesNotExist()
        {
            this.borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.borrower.Address.Contains("Apartment Building");
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfAccountIsNull.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfAccountIsNull()
        {
            Assert.IsNull(this.borrower.Account);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsInvalid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsInvalid()
        {
            this.borrower.Account = new ()
            {
                PhoneNumber = "073452531nnns",
                Email = "123mail.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.borrower.Account.PhoneNumber);
            Assert.IsFalse(phoneNumberFlag);
            Assert.AreNotEqual(10, this.borrower.Account.PhoneNumber.Length);
            Assert.IsFalse(emailFlag);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsValid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsValid()
        {
            this.borrower.Account = new ()
            {
                PhoneNumber = "073452531nnns",
                Email = "validemail@ceva.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.borrower.Account.PhoneNumber);
            Assert.IsFalse(phoneNumberFlag);
            Assert.AreNotEqual(10, this.borrower.Account.PhoneNumber.Length);

            Assert.IsTrue(emailFlag);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeInvalidIfPhoneNumberIsValidAndEmailIsInvalid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsValidAndEmailIsInvalid()
        {
            this.borrower.Account = new ()
            {
                PhoneNumber = "0724525672",
                Email = "invalidemail.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.borrower.Account.PhoneNumber);
            Assert.IsTrue(phoneNumberFlag);
            Assert.AreEqual(10, this.borrower.Account.PhoneNumber.Length);
            Assert.IsFalse(emailFlag);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeValidIfPhoneNumberIsValidAndEmailIsValid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeValidIfPhoneNumberIsValidAndEmailIsValid()
        {
            this.borrower.Account = new ()
            {
                PhoneNumber = "0724525672",
                Email = "validmail@ceva.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.borrower.Account.PhoneNumber);
            Assert.IsTrue(phoneNumberFlag);
            Assert.AreEqual(10, this.borrower.Account.PhoneNumber.Length);

            Assert.IsTrue(emailFlag);
        }

        /// <summary>
        /// Defines the test method AccountIdShouldBeMoreThan1.
        /// </summary>
        [TestMethod]
        public void AccountIdShouldBeMoreThan1()
        {
            this.borrower.AccountId = 1;

            var flag = this.borrower.AccountId > 0 ? true : false;
            Assert.IsTrue(flag);
        }
    }
}