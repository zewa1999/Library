using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Library.DataLayer.Tests.RepositorySpecflow
{
    [Binding]
    public sealed class GetById
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public GetById(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I want to get data from the (.*) with the Id (.*)")]
        public void GivenIWantToGetDataFromTheWithTheId(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the GetByID method")]
        public void WhenICallTheGetByIDMethod()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The Id is valid")]
        public void WhenTheIdIsValid()
        {
            ScenarioContext.Current.Pending();
        }
    }
}