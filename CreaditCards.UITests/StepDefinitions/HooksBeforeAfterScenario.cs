
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CreaditCards.UITests.StepDefinitions
{
    [Binding]
    class HooksBeforeAfterScenario
    {
        private StepDefinitionsContextInjection _context;
        HooksBeforeAfterScenario(StepDefinitionsContextInjection context)
        {
            _context = context;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _context._driver = new FirefoxDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _context._driver.Dispose();
        }
    }
}
