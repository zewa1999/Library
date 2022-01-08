using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Library.DataLayer.Tests.RepositorySpecflow
{
    [Binding]
    public sealed class DeleteById
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public DeleteById(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I want to delete data from the (.*)")]
        public void GivenIWantToDeleteDataFromThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Delete method for the object with the id that I created")]
        public void WhenICallTheDeleteMethodForTheObjectWithTheIdThatICreated()
        {
            ScenarioContext.Current.Pending();
        }
    }
}