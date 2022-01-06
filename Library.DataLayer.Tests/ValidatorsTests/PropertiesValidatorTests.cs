using FluentValidation.TestHelper;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Library.DataLayer.Tests.ValidatorsTests
{
    [TestClass]
    public class PropertiesValidatorTests
    {
        private PropertiesValidator validator;
        [TestInitialize]
        public void Initialize()
        {
            validator = new();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDomeniiIsNull()
        {
            var model = new Properties()
            {
                Domenii = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Domenii);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDomeniiIsNotNull()
        {
            var model = new Properties()
            {
                Domenii = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Domenii);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDomeniiIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                Domenii = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Domenii);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDomeniiIsGreaterThan1()
        {
            var model = new Properties()
            {
                Domenii = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Domenii);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateIsNull()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutate = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NrMaximCartiImprumutate);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateIsNotNull()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutate = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NrMaximCartiImprumutate);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutate = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NrMaximCartiImprumutate);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateIsGreaterThan1()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutate = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NrMaximCartiImprumutate);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPerioadaIsNull()
        {
            var model = new Properties()
            {
                Perioada = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Perioada);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPerioadaIsNotNull()
        {
            var model = new Properties()
            {
                Perioada = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Perioada);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPerioadaIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                Perioada = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Perioada);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPerioadaIsGreaterThan1()
        {
            var model = new Properties()
            {
                Perioada = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Perioada);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNull()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutateAcelasiDomeniu = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NrMaximCartiImprumutateAcelasiDomeniu);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNotNull()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutateAcelasiDomeniu = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NrMaximCartiImprumutateAcelasiDomeniu);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutateAcelasiDomeniu = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NrMaximCartiImprumutateAcelasiDomeniu);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNrMaximCartiImprumutateAcelasiDomeniuIsGreaterThan1()
        {
            var model = new Properties()
            {
                NrMaximCartiImprumutateAcelasiDomeniu = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NrMaximCartiImprumutateAcelasiDomeniu);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarMaximCartiIsNull()
        {
            var model = new Properties()
            {
                NumarMaximCarti = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumarMaximCarti);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarMaximCartiIsNotNull()
        {
            var model = new Properties()
            {
                NumarMaximCarti = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumarMaximCarti);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarMaximCartiIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                NumarMaximCarti = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumarMaximCarti);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarMaximCartiIsGreaterThan1()
        {
            var model = new Properties()
            {
                NumarMaximCarti = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumarMaximCarti);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLimitaMaximaImprumutIsNull()
        {
            var model = new Properties()
            {
                LimitaMaximaImprumut = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LimitaMaximaImprumut);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLimitaMaximaImprumutIsNotNull()
        {
            var model = new Properties()
            {
                LimitaMaximaImprumut = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LimitaMaximaImprumut);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenLimitaMaximaImprumutIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                LimitaMaximaImprumut = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.LimitaMaximaImprumut);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenLimitaMaximaImprumutIsGreaterThan1()
        {
            var model = new Properties()
            {
                LimitaMaximaImprumut = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.LimitaMaximaImprumut);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDeltaIsNull()
        {
            var model = new Properties()
            {
                Delta = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Delta);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDeltaIsNotNull()
        {
            var model = new Properties()
            {
                Delta = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Delta);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDeltaIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                Delta = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Delta);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenDeltaIsGreaterThan1()
        {
            var model = new Properties()
            {
                Delta = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Delta);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarCartiImprumutateZilnicIsNull()
        {
            var model = new Properties()
            {
                NumarCartiImprumutateZilnic = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumarCartiImprumutateZilnic);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarCartiImprumutateZilnicIsNotNull()
        {
            var model = new Properties()
            {
                NumarCartiImprumutateZilnic = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumarCartiImprumutateZilnic);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNumarCartiImprumutateZilnicIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                NumarCartiImprumutateZilnic = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.NumarCartiImprumutateZilnic);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenNumarCartiImprumutateZilnicIsGreaterThan1()
        {
            var model = new Properties()
            {
                NumarCartiImprumutateZilnic = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.NumarCartiImprumutateZilnic);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPersimpIsNull()
        {
            var model = new Properties()
            {
                Persimp = null
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Persimp);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPersimpIsNotNull()
        {
            var model = new Properties()
            {
                Persimp = 3
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Persimp);
        }

        [TestMethod]
        public void ShouldHaveErrorWhenPersimpIsNotGreaterThan1()
        {
            var model = new Properties()
            {
                Persimp = 0
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(a => a.Persimp);
        }

        [TestMethod]
        public void ShouldNotHaveErrorWhenPersimpIsGreaterThan1()
        {
            var model = new Properties()
            {
                Persimp = 2
            };

            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(a => a.Persimp);
        }
    }
}
