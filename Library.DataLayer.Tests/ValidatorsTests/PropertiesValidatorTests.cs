// <copyright file="PropertiesValidatorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DataLayer.Tests.ValidatorsTests
{
    using FluentValidation.TestHelper;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PropertiesValidatorTests
    {
        private PropertiesValidator validator;

        [TestInitialize]
        public void Initialize()
        {
            this.validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDomeniiIsNull()
        {
            var model = new Properties()
            {
                DOMENII = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.DOMENII);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDomeniiIsNotNull()
        {
            var model = new Properties()
            {
                DOMENII = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.DOMENII);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDomeniiIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                DOMENII = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.DOMENII);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDomeniiIsGreaterThan1()
        {
            var model = new Properties()
            {
                DOMENII = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.DOMENII);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateIsNull()
        {
            var model = new Properties()
            {
                C = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.C);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateIsNotNull()
        {
            var model = new Properties()
            {
                C = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.C);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                C = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.C);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateIsGreaterThan1()
        {
            var model = new Properties()
            {
                C = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.C);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPerioadaIsNull()
        {
            var model = new Properties()
            {
                PER = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PER);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPerioadaIsNotNull()
        {
            var model = new Properties()
            {
                PER = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.PER);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPerioadaIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                PER = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PER);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPerioadaIsGreaterThan1()
        {
            var model = new Properties()
            {
                PER = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.PER);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNull()
        {
            var model = new Properties()
            {
                D = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.D);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNotNull()
        {
            var model = new Properties()
            {
                D = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.D);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                D = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.D);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsGreaterThan1()
        {
            var model = new Properties()
            {
                D = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.D);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarMaximCartiIsNull()
        {
            var model = new Properties()
            {
                NMC = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NMC);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarMaximCartiIsNotNull()
        {
            var model = new Properties()
            {
                NMC = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NMC);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarMaximCartiIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                NMC = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NMC);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarMaximCartiIsGreaterThan1()
        {
            var model = new Properties()
            {
                NMC = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NMC);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLimitaMaximaImprumutIsNull()
        {
            var model = new Properties()
            {
                LIM = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LIM);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLimitaMaximaImprumutIsNotNull()
        {
            var model = new Properties()
            {
                LIM = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LIM);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLimitaMaximaImprumutIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                LIM = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LIM);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLimitaMaximaImprumutIsGreaterThan1()
        {
            var model = new Properties()
            {
                LIM = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LIM);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDeltaIsNull()
        {
            var model = new Properties()
            {
                DELTA = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.DELTA);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDeltaIsNotNull()
        {
            var model = new Properties()
            {
                DELTA = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.DELTA);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDeltaIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                DELTA = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.DELTA);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDeltaIsGreaterThan1()
        {
            var model = new Properties()
            {
                DELTA = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.DELTA);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarCartiImprumutateZilnicIsNull()
        {
            var model = new Properties()
            {
                NCZ = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NCZ);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarCartiImprumutateZilnicIsNotNull()
        {
            var model = new Properties()
            {
                NCZ = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NCZ);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarCartiImprumutateZilnicIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                NCZ = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NCZ);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarCartiImprumutateZilnicIsGreaterThan1()
        {
            var model = new Properties()
            {
                NCZ = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NCZ);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPersimpIsNull()
        {
            var model = new Properties()
            {
                PERSIMP = null,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PERSIMP);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPersimpIsNotNull()
        {
            var model = new Properties()
            {
                PERSIMP = 3,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.PERSIMP);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPersimpIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                PERSIMP = 0,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.PERSIMP);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPersimpIsGreaterThan1()
        {
            var model = new Properties()
            {
                PERSIMP = 2,
            };

            var result = this.validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.PERSIMP);
        }
    }
}