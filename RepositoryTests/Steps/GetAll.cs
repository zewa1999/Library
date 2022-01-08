using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Library.DataLayer.Tests.RepositorySpecflow
{
    [Binding]
    public sealed class GetAll
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public GetAll(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I want to get all data from the (.*)")]
        public void GivenIWantToGetAllDataFromThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Get method")]
        public void WhenICallTheGetMethod()
        {
            ScenarioContext.Current.Pending();
        }
    }
}