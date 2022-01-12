// <copyright file="BorrowValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class BorrowValidatorTests.
    /// </summary>
    [TestClass]
    public class BorrowValidatorTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private BorrowValidator validator;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.validator = new ();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNoOfTimeExtendedIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenNoOfTimeExtendedIsNull()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNoOfTimeExtendedIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenNoOfTimeExtendedIsNotNull()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNoOfTimeExtendedIsNotGreaterThan1.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenNoOfTimeExtendedIsNotGreaterThan1()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNoOfTimeExtendedIsGreaterThan1.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenNoOfTimeExtendedIsGreaterThan1()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNoOfTimeExtendedIsGreaterThan3.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenNoOfTimeExtendedIsGreaterThan3()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 5,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenBorrowDateIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenBorrowDateIsNull()
        {
            var model = new Borrow()
            {
                BorrowDate = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.BorrowDate);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenBorrowDateIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenBorrowDateIsNotNull()
        {
            var model = new Borrow()
            {
                BorrowDate = DateTime.Now.AddMonths(-1),
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.BorrowDate);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEndDateIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEndDateIsNull()
        {
            var model = new Borrow()
            {
                EndDate = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.EndDate);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenEndDateIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenEndDateIsNotNull()
        {
            var model = new Borrow()
            {
                EndDate = DateTime.Now,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.EndDate);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenBorrowedBooksCollectionIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenBorrowedBooksCollectionIsNull()
        {
            var model = new Borrow()
            {
                BorrowedBooks = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.BorrowedBooks);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenBorrowedBooksCollectionIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenBorrowedBooksCollectionIsEmpty()
        {
            var model = new Borrow()
            {
                BorrowedBooks = new List<Book>(),
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.BorrowedBooks);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenBorrowDateIsHighenThanDateTimeNow.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenBorrowDateIsHighenThanDateTimeNow()
        {
            var model = new Borrow()
            {
                BorrowDate = DateTime.Now.AddMonths(1),
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.BorrowDate);
        }
    }
}