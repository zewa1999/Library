// ***********************************************************************
// Assembly         : Library.DomainLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="AccountTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Tests
{
    using System;
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class AccountTests.
    /// </summary>
    [TestClass]
    public class AccountTests
    {
        /// <summary>
        /// The account.
        /// </summary>
        private Account account;

        /// <summary>
        /// Initializes the test.
        /// </summary>
        [TestInitialize]
        public void InitializeTest()
        {
            this.account = new ();
        }

        /// <summary>
        /// Defines the test method AccountPhoneNumberShouldBeWrongIfLenghtIsNot10.
        /// </summary>
        [TestMethod]
        public void AccountPhoneNumberShouldBeWrongIfLenghtIsNot10()
        {
            this.account.PhoneNumber = "0721";

            Assert.AreNotEqual(10, this.account.PhoneNumber.Length);
        }

        /// <summary>
        /// Defines the test method AccountPhoneNumberShouldBeNull.
        /// </summary>
        [TestMethod]
        public void AccountPhoneNumberShouldBeNull()
        {
            this.account.PhoneNumber = null;

            Assert.IsNull(this.account.PhoneNumber);
        }

        /// <summary>
        /// Defines the test method AccountIdShouldBeValid.
        /// </summary>
        [TestMethod]
        public void AccountIdShouldBeValid()
        {
            this.account.Id = 1;

            Assert.AreEqual(1, this.account.Id);
        }

        /// <summary>
        /// Defines the test method AccountEmailShouldBeValid.
        /// </summary>
        [TestMethod]
        public void AccountEmailShouldBeValid()
        {
            this.account.Email = "email@email.com";
            bool flag = true;
            var trimmedEmail = this.account.Email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                flag = false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(this.account.Email);
                flag = addr.Address == trimmedEmail;
            }
            catch
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Defines the test method AccountEmailShouldBeInvalidAndThrowException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AccountEmailShouldBeInvalidAndThrowException()
        {
            this.account.Email = "emailNotValid";

            var trimmedEmail = this.account.Email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                throw new AssertFailedException("The email is not valid");
            }

            new System.Net.Mail.MailAddress(this.account.Email);
        }
    }
}