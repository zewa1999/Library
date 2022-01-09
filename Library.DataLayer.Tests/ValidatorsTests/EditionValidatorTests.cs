using FluentValidation.TestHelper;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.DataLayer.Tests.ValidatorsTests
{
    [TestClass]
    public class EditionValidatorTests
    {
        private EditionValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPublisherIsNull()
        {
            var model = new Edition()
            {
                Publisher = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Publisher);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPublisherIsNotNull()
        {
            var model = new Edition()
            {
                Publisher = "NotNull"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Publisher);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPublisherIsEmpty()
        {
            var model = new Edition()
            {
                Publisher = ""
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Publisher);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPublisherIsNotEmpty()
        {
            var model = new Edition()
            {
                Publisher = "notEmpty"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Publisher);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPublisherLenghtIsLessThanOne()
        {
            var model = new Edition()
            {
                Publisher = "q"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Publisher);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPublisherIsHigherThanOne()
        {
            var model = new Edition()
            {
                Publisher = "qwert"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Publisher);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenYearIsNull()
        {
            var model = new Edition()
            {
                Year = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Year);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenYearIsNotNull()
        {
            var model = new Edition()
            {
                Year = "134"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Year);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenYearIsEmpty()
        {
            var model = new Edition()
            {
                Year = ""
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Year);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenYearIsNotEmpty()
        {
            var model = new Edition()
            {
                Year = "124"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Year);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenYearIsHigherThanOne()
        {
            var model = new Edition()
            {
                Year = "1234"
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Year);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEditionNumberIsNull()
        {
            var model = new Edition()
            {
                EditionNumber = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.EditionNumber);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenEditionNumberIsNotNull()
        {
            var model = new Edition()
            {
                EditionNumber = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.EditionNumber);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenEditionNumberIsNotGreaterThan1()
        {
            var model = new Edition()
            {
                EditionNumber = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.EditionNumber);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenEditionNumberIsGreaterThan1()
        {
            var model = new Edition()
            {
                EditionNumber = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.EditionNumber);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumberOfPagesIsNull()
        {
            var model = new Edition()
            {
                NumberOfPages = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumberOfPages);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumberOfPagesIsNotNull()
        {
            var model = new Edition()
            {
                NumberOfPages = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumberOfPages);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumberOfPagesIsNotGreaterThan1()
        {
            var model = new Edition()
            {
                NumberOfPages = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumberOfPages);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumberOfPagesIsGreaterThan1()
        {
            var model = new Edition()
            {
                NumberOfPages = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumberOfPages);
        }
    }
}