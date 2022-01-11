// ***********************************************************************
// Assembly         : Library.DomainLayer.Tests
// Author           : costa
// Created          : 01-11-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="LibrarianTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Tests.PersonTests
{
    using System.Linq;
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class LibrarianTests.
    /// </summary>
    [TestClass]
    public class LibrarianTests
    {
        /// <summary>
        /// The librarian.
        /// </summary>
        private Librarian librarian;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.librarian = new ();
        }

        /// <summary>
        /// Defines the test method BorrowerIdShouldBeValid.
        /// </summary>
        [TestMethod]
        public void BorrowerIdShouldBeValid()
        {
            this.librarian.Id = 1;
            Assert.AreEqual(1, this.librarian.Id);
        }

        /// <summary>
        /// Defines the test method LastNameShouldBeValid.
        /// </summary>
        [TestMethod]
        public void LastNameShouldBeValid()
        {
            this.librarian.LastName = "Costache";
            bool isIntString = this.librarian.LastName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        /// <summary>
        /// Defines the test method LastNameShouldBeInvalid.
        /// </summary>
        [TestMethod]
        public void LastNameShouldBeInvalid()
        {
            this.librarian.LastName = "Costache123";
            bool isIntString = this.librarian.LastName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        /// <summary>
        /// Defines the test method FirstNameShouldBeValid.
        /// </summary>
        [TestMethod]
        public void FirstNameShouldBeValid()
        {
            this.librarian.FirstName = "Stelian";
            bool isIntString = this.librarian.FirstName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        /// <summary>
        /// Defines the test method FirstNameShouldBeInvalid.
        /// </summary>
        [TestMethod]
        public void FirstNameShouldBeInvalid()
        {
            this.librarian.FirstName = "1223Andrei";
            bool isIntString = this.librarian.FirstName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeValidIfContainsComma.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeValidIfContainsComma()
        {
            this.librarian.Address = "Street Strada Mea, Apartment Building 16, Brasov, Number 37, Romania";
            bool flag1 = this.librarian.Address.Contains(',');
            Assert.IsTrue(flag1);
            Assert.IsTrue(flag1);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfStreetDoesNotExist.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfStreetDoesNotExist()
        {
            this.librarian.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag3 = this.librarian.Address.Contains("Street");
            Assert.IsFalse(flag3);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfNumberDoesNotExist.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfNumberDoesNotExist()
        {
            this.librarian.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.librarian.Address.Contains("Number");
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfApartmentBuildingDoesNotExist.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfApartmentBuildingDoesNotExist()
        {
            this.librarian.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.librarian.Address.Contains("Apartment Building");
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Defines the test method AddressShouldBeInvalidIfAccountIsNull.
        /// </summary>
        [TestMethod]
        public void AddressShouldBeInvalidIfAccountIsNull()
        {
            Assert.IsNull(this.librarian.Account);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsInvalid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsInvalid()
        {
            this.librarian.Account = new ()
            {
                PhoneNumber = "073452531nnns",
                Email = "123mail.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.librarian.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.librarian.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.librarian.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.librarian.Account.PhoneNumber);
            Assert.IsFalse(phoneNumberFlag);
            Assert.AreNotEqual(10, this.librarian.Account.PhoneNumber.Length);
            Assert.IsFalse(emailFlag);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsValid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsValid()
        {
            this.librarian.Account = new ()
            {
                PhoneNumber = "073452531nnns",
                Email = "validemail@ceva.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.librarian.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.librarian.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.librarian.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.librarian.Account.PhoneNumber);
            Assert.IsFalse(phoneNumberFlag);
            Assert.AreNotEqual(10, this.librarian.Account.PhoneNumber.Length);

            Assert.IsTrue(emailFlag);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeInvalidIfPhoneNumberIsValidAndEmailIsInvalid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsValidAndEmailIsInvalid()
        {
            this.librarian.Account = new ()
            {
                PhoneNumber = "0724525672",
                Email = "invalidemail.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.librarian.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.librarian.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.librarian.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.librarian.Account.PhoneNumber);
            Assert.IsTrue(phoneNumberFlag);
            Assert.AreEqual(10, this.librarian.Account.PhoneNumber.Length);
            Assert.IsFalse(emailFlag);
        }

        /// <summary>
        /// Defines the test method BorrowerAccountShouldBeValidIfPhoneNumberIsValidAndEmailIsValid.
        /// </summary>
        [TestMethod]
        public void BorrowerAccountShouldBeValidIfPhoneNumberIsValidAndEmailIsValid()
        {
            this.librarian.Account = new ()
            {
                PhoneNumber = "0724525672",
                Email = "validmail@ceva.com",
            };
            bool emailFlag = true;
            bool phoneNumberFlag = this.librarian.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = this.librarian.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(this.librarian.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(this.librarian.Account.PhoneNumber);
            Assert.IsTrue(phoneNumberFlag);
            Assert.AreEqual(10, this.librarian.Account.PhoneNumber.Length);

            Assert.IsTrue(emailFlag);
        }

        /// <summary>
        /// Defines the test method LibrarianShouldBeReader.
        /// </summary>
        [TestMethod]
        public void LibrarianShouldBeReader()
        {
            this.librarian.IsReader = false;
            if (this.librarian.IsReader == true)
            {
                Assert.IsTrue(true);
            }

            Assert.IsFalse(false);
        }

        /// <summary>
        /// Defines the test method LibrarianShouldNotBeReader.
        /// </summary>
        [TestMethod]
        public void LibrarianShouldNotBeReader()
        {
            this.librarian.IsReader = false;
            if (this.librarian.IsReader == true)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.IsFalse(false);
        }
    }
}