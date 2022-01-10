namespace Library.DomainLayer.Tests
{
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class AccountTests
    {
        private Account account;

        [TestInitialize]
        public void InitializeTest()
        {
            this.account = new();
        }

        [TestMethod]
        public void AccountPhoneNumberShouldBeWrongIfLenghtIsNot10()
        {
            this.account.PhoneNumber = "0721";

            Assert.AreNotEqual(10, this.account.PhoneNumber.Length);
        }

        [TestMethod]
        public void AccountPhoneNumberShouldBeNull()
        {
            this.account.PhoneNumber = null;

            Assert.IsNull(this.account.PhoneNumber);
        }

        [TestMethod]
        public void AccountIdShouldBeValid()
        {
            this.account.Id = 1;

            Assert.AreEqual(1, this.account.Id);
        }

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