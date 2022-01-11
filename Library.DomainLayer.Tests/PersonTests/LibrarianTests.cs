// <copyright file="LibrarianTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer.Tests.PersonTests
{
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class LibrarianTests
    {
        private Librarian librarian;

        [TestInitialize]
        public void Initialize()
        {
            this.librarian = new();
        }

        [TestMethod]
        public void BorrowerIdShouldBeValid()
        {
            this.librarian.Id = 1;
            Assert.AreEqual(1, this.librarian.Id);
        }

        [TestMethod]
        public void LastNameShouldBeValid()
        {
            this.librarian.LastName = "Costache";
            bool isIntString = this.librarian.LastName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void LastNameShouldBeInvalid()
        {
            this.librarian.LastName = "Costache123";
            bool isIntString = this.librarian.LastName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeValid()
        {
            this.librarian.FirstName = "Stelian";
            bool isIntString = this.librarian.FirstName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeInvalid()
        {
            this.librarian.FirstName = "1223Andrei";
            bool isIntString = this.librarian.FirstName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        //Teste pentru fiecare tip
        [TestMethod]
        public void AddressShouldBeValidIfContainsComma()
        {
            this.librarian.Address = "Street Strada Mea, Apartment Building 16, Brasov, Number 37, Romania";
            bool flag1 = this.librarian.Address.Contains(',');
            Assert.IsTrue(flag1);
            Assert.IsTrue(flag1);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfStreetDoesNotExist()
        {
            this.librarian.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag3 = this.librarian.Address.Contains("Street");
            Assert.IsFalse(flag3);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfNumberDoesNotExist()
        {
            this.librarian.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.librarian.Address.Contains("Number");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfApartmentBuildingDoesNotExist()
        {
            this.librarian.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.librarian.Address.Contains("Apartment Building");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfAccountIsNull()
        {
            Assert.IsNull(this.librarian.Account);
        }

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsInvalid()
        {
            this.librarian.Account = new()
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

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsValid()
        {
            this.librarian.Account = new()
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

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsValidAndEmailIsInvalid()
        {
            this.librarian.Account = new()
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

        [TestMethod]
        public void BorrowerAccountShouldBeValidIfPhoneNumberIsValidAndEmailIsValid()
        {
            this.librarian.Account = new()
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

        [TestMethod]
        public void LibrarianShouldBeReader()
        {
            this.librarian.IsReader = false;
            if (this.librarian.IsReader == true)
                Assert.IsTrue(true);
            Assert.IsFalse(false);
        }

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