using CreaditCards.UITests.PageObjectModels;
using System.Threading;
using TechTalk.SpecFlow;

namespace CreaditCards.UITests.StepDefinitions
{
    [Binding]
    class AboutPageSteps
    {
        private StepDefinitionsContextInjection _context;
        AboutPageSteps(StepDefinitionsContextInjection context)
        {
            _context = context;
        }

        [Given(@"I go to the About page")]
        public void GivenIGoToTheAboutPage()
        {
            _context.AboutPage = new AboutPage(_context._driver);
            _context.AboutPage.NavigateTo(_context._driver);
        }

        [When(@"I go back from the About Page")]
        public void WhenIGoBack()
        {
            _context.AboutPage.GoBackwards();
        }
        [Then(@"I am on About page")]
        public void ThenIAmOnAboutPage()
        {
            Thread.Sleep(1000);
            _context.AboutPage = new AboutPage(_context._driver);
            _context.AboutPage.EnsurePageLoaded();
        }



    }
}
