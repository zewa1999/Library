using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Library.DataLayer.Tests.RepositorySpecflow
{
    [Binding]
    public sealed class Insert
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public Insert(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I want to insert data into the (.*)")]
        public void GivenIWantToInsertDataIntoThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call the Insert method")]
        public void WhenICallTheInsertMethod()
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