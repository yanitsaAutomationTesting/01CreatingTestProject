using TechTalk.SpecFlow;

namespace CreaditCards.UITests.StepDefinitions
{
    [Binding]
    class ApplicationCompletePageSteps
    {
        private StepDefinitionsContextInjection _context;
        ApplicationCompletePageSteps(StepDefinitionsContextInjection context)
        {
            _context = context;
        }

        [When(@"I am on the Application Complete Page")]
        public void WhenIAmOnTheApplicationCompletePage()
        {
            _context.ApplicationCompletePage.EnsurePageLoaded();
        }

        [Then(@"the full name is (.*)")]
        public void ThenTheFullNameIsSarahParker(string fullName)
        {
            _context.ApplicationCompletePage.verifyFullName(fullName);
        }




    }
}
