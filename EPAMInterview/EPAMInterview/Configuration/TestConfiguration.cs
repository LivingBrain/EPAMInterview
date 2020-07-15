using System;
using TechTalk.SpecFlow;

namespace EPAMInterview.Configuration
{
    [Binding]
    public class TestConfiguration
    {
        private readonly ScenarioContext scenarioContext;

        public TestConfiguration(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException(nameof(scenarioContext));
            }
            this.scenarioContext = scenarioContext;
        }

        protected DriverContext DriverContext { get; } = new DriverContext();

        [Before(Order = 0)]
        public void BeforeTest()
        {
            this.scenarioContext["DriverContext"] = this.DriverContext;
            this.DriverContext.Start();
            this.DriverContext.WindowMaximize();
        }

        [After(Order = 1)]
        public void AfterTest()
        {
            this.DriverContext.Stop();
        }
    }
}
