// ***********************************************************************
// Assembly         : Library.DataLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="EditionValidatorTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class EditionValidatorTests.
    /// </summary>
    [TestClass]
    public class EditionValidatorTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private EditionValidator validator;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.validator = new ();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPublisherIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenPublisherIsNull()
        {
            var model = new Edition()
            {
                Publisher = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Publisher);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPublisherIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPublisherIsNotNull()
        {
            var model = new Edition()
            {
                Publisher = "NotNull",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Publisher);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPublisherIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenPublisherIsEmpty()
        {
            var model = new Edition()
            {
                Publisher = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Publisher);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPublisherIsNotEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPublisherIsNotEmpty()
        {
            var model = new Edition()
            {
                Publisher = "notEmpty",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Publisher);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPublisherLenghtIsLessThanOne.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenPublisherLenghtIsLessThanOne()
        {
            var model = new Edition()
            {
                Publisher = "q",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Publisher);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPublisherIsHigherThanOne.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenPublisherIsHigherThanOne()
        {
            var model = new Edition()
            {
                Publisher = "qwert",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Publisher);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenYearIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenYearIsNull()
        {
            var model = new Edition()
            {
                Year = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Year);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenYearIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenYearIsNotNull()
        {
            var model = new Edition()
            {
                Year = "134",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Year);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenYearIsEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenYearIsEmpty()
        {
            var model = new Edition()
            {
                Year = string.Empty,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Year);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenYearIsNotEmpty.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenYearIsNotEmpty()
        {
            var model = new Edition()
            {
                Year = "124",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Year);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenYearIsHigherThanOne.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenYearIsHigherThanOne()
        {
            var model = new Edition()
            {
                Year = "1234",
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Year);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEditionNumberIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEditionNumberIsNull()
        {
            var model = new Edition()
            {
                EditionNumber = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.EditionNumber);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenEditionNumberIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenEditionNumberIsNotNull()
        {
            var model = new Edition()
            {
                EditionNumber = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.EditionNumber);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenEditionNumberIsNotGreaterThan1.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenEditionNumberIsNotGreaterThan1()
        {
            var model = new Edition()
            {
                EditionNumber = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.EditionNumber);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenEditionNumberIsGreaterThan1.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenEditionNumberIsGreaterThan1()
        {
            var model = new Edition()
            {
                EditionNumber = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.EditionNumber);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNumberOfPagesIsNull.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenNumberOfPagesIsNull()
        {
            var model = new Edition()
            {
                NumberOfPages = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumberOfPages);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNumberOfPagesIsNotNull.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenNumberOfPagesIsNotNull()
        {
            var model = new Edition()
            {
                NumberOfPages = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumberOfPages);
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNumberOfPagesIsNotGreaterThan1.
        /// </summary>
        [TestMethod]
        public void ShouldHaveErrorWhenNumberOfPagesIsNotGreaterThan1()
        {
            var model = new Edition()
            {
                NumberOfPages = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumberOfPages);
        }

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNumberOfPagesIsGreaterThan1.
        /// </summary>
        [TestMethod]
        public void ShouldNotHaveErrorWhenNumberOfPagesIsGreaterThan1()
        {
            var model = new Edition()
            {
                NumberOfPages = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumberOfPages);
        }
    }
}