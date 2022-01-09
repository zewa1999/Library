using Library.DomainLayer.Person;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Library.DomainLayer.Tests
{
    [TestClass]
    public class AccountTests
    {
        private Account account;

        [TestInitialize]
        public void InitializeTest()
        {
            account = new();
        }

        [TestMethod]
        public void AccountPhoneNumberShouldBeWrongIfLenghtIsNot10()
        {
            account.PhoneNumber = "0721";

            Assert.AreNotEqual(10, account.PhoneNumber.Length);
        }

        [TestMethod]
        public void AccountPhoneNumberShouldBeNull()
        {
            account.PhoneNumber = null;

            Assert.IsNull(account.PhoneNumber);
        }

        [TestMethod]
        public void AccountIdShouldBeValid()
        {
            account.Id = 1;

            Assert.AreEqual(1, account.Id);
        }

        [TestMethod]
        public void AccountEmailShouldBeValid()
        {
            account.Email = "email@email.com";
            bool flag = true;
            var trimmedEmail = account.Email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                flag = false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(account.Email);
                flag = addr.Address == trimmedEmail;
            }
            catch
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AccountEmailShouldBeInvalidAndThrowException()
        {
            account.Email = "emailNotValid";

            var trimmedEmail = account.Email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                throw new AssertFailedException("The email is not valid");
            }

            new System.Net.Mail.MailAddress(account.Email);
        }
    }
}