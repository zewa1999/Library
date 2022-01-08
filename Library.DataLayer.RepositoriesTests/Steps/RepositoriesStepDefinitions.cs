using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Library.DataLayer.RepositoriesTests.Steps
{
    [Binding]
    public class RepositoryTestsSteps
    {
        [Given(@"I want to insert data into the (.*)")]
        public void GivenIWantToInsertDataIntoThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I want to update data from the (.*)")]
        public void GivenIWantToUpdateDataFromThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I want to get data from the (.*) with the Id (.*)")]
        public void GivenIWantToGetDataFromTheWithTheId(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The Id is valid")]
        public void GivenTheIdIsValid()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I want to get all data from the (.*)")]
        public void GivenIWantToGetAllDataFromThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I want to delete data from the (.*)")]
        public void GivenIWantToDeleteDataFromThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I create an object to delete")]
        public void GivenICreateAnObjectToDelete()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Insert method")]
        public void WhenICallTheInsertMethod()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Update method")]
        public void WhenICallTheUpdateMethod()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the GetByID method")]
        public void WhenICallTheGetByIDMethod()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Get method")]
        public void WhenICallTheGetMethod()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Delete method")]
        public void WhenICallTheDeleteMethod()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Delete method for the object with the id that I created")]
        public void WhenICallTheDeleteMethodForTheObjectWithTheIdThatICreated()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should have a valid result")]
        public void ThenIShouldHaveAValidResult(Table table)
        {
            Assert.IsTrue(true);
        }
    }
}