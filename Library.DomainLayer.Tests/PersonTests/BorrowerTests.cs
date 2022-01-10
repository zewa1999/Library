namespace Library.DomainLayer.Tests
{
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class BorrowerTests
    {
        private Borrower borrower;

        [TestInitialize]
        public void Initialize()
        {
            this.borrower = new();
        }

        [TestMethod]
        public void BorrowerIdShouldBeValid()
        {
            this.borrower.Id = 1;
            Assert.AreEqual(1, this.borrower.Id);
        }

        [TestMethod]
        public void LastNameShouldBeValid()
        {
            this.borrower.LastName = "Costache";
            bool isIntString = this.borrower.LastName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void LastNameShouldBeInvalid()
        {
            this.borrower.LastName = "Costache123";
            bool isIntString = this.borrower.LastName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeValid()
        {
            this.borrower.FirstName = "Stelian";
            bool isIntString = this.borrower.FirstName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeInvalid()
        {
            this.borrower.FirstName = "1223Andrei";
            bool isIntString = this.borrower.FirstName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        //Teste pentru fiecare tip
        [TestMethod]
        public void AddressShouldBeValidIfContainsComma()
        {
            this.borrower.Address = "Street Strada Mea, Apartment Building 16, Brasov, Number 37, Romania";
            bool flag1 = this.borrower.Address.Contains(',');
            Assert.IsTrue(flag1);
            Assert.IsTrue(flag1);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfStreetDoesNotExist()
        {
            this.borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag3 = this.borrower.Address.Contains("Street");
            Assert.IsFalse(flag3);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfNumberDoesNotExist()
        {
            this.borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.borrower.Address.Contains("Number");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfApartmentBuildingDoesNotExist()
        {
            this.borrower.Address = "Apartment Building 16, Brasov, Number 37, Romania";
            bool flag = this.borrower.Address.Contains("Apartment Building");
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void AddressShouldBeInvalidIfAccountIsNull()
        {
            Assert.IsNull(this.borrower.Account);
        }

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsInvalid()
        {
            this.borrower.Account = new()
            {
                PhoneNumber = "073452531nnns",
                Email = "123mail.com"
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

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsInvalidAndEmailIsValid()
        {
            this.borrower.Account = new()
            {
                PhoneNumber = "073452531nnns",
                Email = "validemail@ceva.com"
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

        [TestMethod]
        public void BorrowerAccountShouldBeInvalidIfPhoneNumberIsValidAndEmailIsInvalid()
        {
            this.borrower.Account = new()
            {
                PhoneNumber = "0724525672",
                Email = "invalidemail.com"
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

        [TestMethod]
        public void BorrowerAccountShouldBeValidIfPhoneNumberIsValidAndEmailIsValid()
        {
            this.borrower.Account = new()
            {
                PhoneNumber = "0724525672",
                Email = "validmail@ceva.com"
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
    }
}