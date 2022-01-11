// ***********************************************************************
// Assembly         : Library.DataLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="PropertiesValidatorTests.cs" company="Transilvania University of Brasov">
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
    /// Defines test class PropertiesValidatorTests.
    /// </summary>
    [TestClass]
    public class PropertiesValidatorTests
    {
        /// <summary>
        /// The validator.
        /// </summary>
        private PropertiesValidator validator;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.validator = new ();
        }

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenDomeniiIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenDomeniiIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenDomeniiIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenDomeniiIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNrMaximCartiImprumutateIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNrMaximCartiImprumutateIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNrMaximCartiImprumutateIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNrMaximCartiImprumutateIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPerioadaIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPerioadaIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPerioadaIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPerioadaIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNumarMaximCartiIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNumarMaximCartiIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNumarMaximCartiIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNumarMaximCartiIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenLimitaMaximaImprumutIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenLimitaMaximaImprumutIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenLimitaMaximaImprumutIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenLimitaMaximaImprumutIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenDeltaIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenDeltaIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenDeltaIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenDeltaIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNumarCartiImprumutateZilnicIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNumarCartiImprumutateZilnicIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenNumarCartiImprumutateZilnicIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenNumarCartiImprumutateZilnicIsGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPersimpIsNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPersimpIsNotNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldHaveErrorWhenPersimpIsNotGreaterThan1.
        /// </summary>
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

        /// <summary>
        /// Defines the test method ShouldNotHaveErrorWhenPersimpIsGreaterThan1.
        /// </summary>
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