using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Library.DataLayer.Tests.RepositorySpecflow
{
    [Binding]
    public sealed class Update
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public Update(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I want to update data from the (.*)")]
        public void GivenIWantToUpdateDataFromThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Update method")]
        public void WhenICallTheUpdateMethod()
        {
            ScenarioContext.Current.Pending();
        }
    }
}