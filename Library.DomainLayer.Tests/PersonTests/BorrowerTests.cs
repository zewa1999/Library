using Library.DomainLayer.Person;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Library.DomainLayer.Tests
{
    [TestClass]
    public class BorrowerTests
    {
        private Borrower borrower;

        [TestInitialize]
        public void Initialize()
        {
            borrower = new();
        }

        [TestMethod]
        public void BorrowerIdShouldBeValid()
        {
            borrower.Id = 1;
            Assert.AreEqual(1, borrower.Id);
        }

        [TestMethod]
        public void LastNameShouldBeValid()
        {
            borrower.LastName = "Costache";
            bool isIntString = borrower.LastName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void LastNameShouldBeInvalid()
        {
            borrower.LastName = "Costache123";
            bool isIntString = borrower.LastName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeValid()
        {
            borrower.FirstName = "Stelian";
            bool isIntString = borrower.FirstName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeInvalid()
        {
            borrower.FirstName = "1223Andrei";
            bool isIntString = borrower.FirstName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        //Teste pentru fiecare tip
        [TestMethod]
        public void AddressShouldBeValidIfContainsComma()
        {
            borrower.Address = "Street Strada Mea, Apartment Building 16, Brasov, Number 37, Romania";
            bool flag1 = borrower.Address.Contains(',');
            Assert.IsTrue(flag1);
            Assert.IsTrue(flag1);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfStreetDoesNotExist()
        {
            borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag3 = borrower.Address.Contains("Street");
            Assert.IsFalse(flag3);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfNumberDoesNotExist()
        {
            borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = borrower.Address.Contains("Number");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfApartmentBuildingDoesNotExist()
        {
            borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = borrower.Address.Contains("Apartment Building");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfAccountIsNull()
        {
            Assert.IsNull(borrower.Account);
        }

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsInvalid()
        {
            borrower.Account = new()
            {
                PhoneNumber = "073452531nnns",
                Email = "123mail.com"
            };
            bool emailFlag = true;
            bool phoneNumberFlag = borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(borrower.Account.PhoneNumber);
            Assert.IsFalse(phoneNumberFlag);
            Assert.AreNotEqual(10, borrower.Account.PhoneNumber.Length);
            Assert.IsFalse(emailFlag);
        }

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsValid()
        {
            borrower.Account = new()
            {
                PhoneNumber = "073452531nnns",
                Email = "validemail@ceva.com"
            };
            bool emailFlag = true;
            bool phoneNumberFlag = borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(borrower.Account.PhoneNumber);
            Assert.IsFalse(phoneNumberFlag);
            Assert.AreNotEqual(10, borrower.Account.PhoneNumber.Length);

            Assert.IsTrue(emailFlag);
        }

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsValidAndEmailIsInvalid()
        {
            borrower.Account = new()
            {
                PhoneNumber = "0724525672",
                Email = "invalidemail.com"
            };
            bool emailFlag = true;
            bool phoneNumberFlag = borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(borrower.Account.PhoneNumber);
            Assert.IsTrue(phoneNumberFlag);
            Assert.AreEqual(10, borrower.Account.PhoneNumber.Length);
            Assert.IsFalse(emailFlag);
        }

        [TestMethod]
        public void BorrowerAccountShouldBeValidIfPhoneNumberIsValidAndEmailIsValid()
        {
            borrower.Account = new()
            {
                PhoneNumber = "0724525672",
                Email = "validmail@ceva.com"
            };
            bool emailFlag = true;
            bool phoneNumberFlag = borrower.Account.PhoneNumber.All(char.IsDigit);

            var trimmedEmail = borrower.Account.Email.Trim();

            try
            {
                if (trimmedEmail.EndsWith("."))
                {
                    throw new AssertFailedException("The email is not valid");
                }

                new System.Net.Mail.MailAddress(borrower.Account.Email);
            }
            catch
            {
                emailFlag = false;
            }

            Assert.IsNotNull(borrower.Account.PhoneNumber);
            Assert.IsTrue(phoneNumberFlag);
            Assert.AreEqual(10, borrower.Account.PhoneNumber.Length);

            Assert.IsTrue(emailFlag);
        }
    }
}