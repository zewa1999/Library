﻿using FluentValidation.TestHelper;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Library.DataLayer.Tests.ValidatorsTests
{
    [TestClass]
    public class BorrowValidatorTests
    {
        private BorrowValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNoOfTimeExtendedIsNull()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNoOfTimeExtendedIsNotNull()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNoOfTimeExtendedIsNotGreaterThan1()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNoOfTimeExtendedIsGreaterThan1()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNoOfTimeExtendedIsGreaterThan3()
        {
            var model = new Borrow()
            {
                NoOfTimeExtended = 5
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NoOfTimeExtended);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenBorrowDateIsNull()
        {
            var model = new Borrow()
            {
                BorrowDate = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.BorrowDate);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenBorrowDateIsNotNull()
        {
            var model = new Borrow()
            {
                BorrowDate = DateTime.Now
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.BorrowDate);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEndDateIsNull()
        {
            var model = new Borrow()
            {
                EndDate = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.EndDate);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenEndDateIsNotNull()
        {
            var model = new Borrow()
            {
                EndDate = DateTime.Now
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.EndDate);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenBorrowedBooksCollectionIsNull()
        {
            var model = new Borrow()
            {
                BorrowedBooks = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.BorrowedBooks);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenBorrowedBooksCollectionIsEmpty()
        {
            var model = new Borrow()
            {
                BorrowedBooks = new List<Book>()
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.BorrowedBooks);
        }
    }
}