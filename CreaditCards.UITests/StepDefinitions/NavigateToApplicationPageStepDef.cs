using CreaditCards.UITests.PageObjectModels;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;
namespace CreaditCards.UITests.StepDefinitions
{
    [Binding]
   public class NavigateToApplicationPageStepDef : TechTalk.SpecFlow.Steps

    {

        private StepDefinitionsContextInjection _context;
         NavigateToApplicationPageStepDef(StepDefinitionsContextInjection context)
        {
            _context = context;
        }


        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            _context.HomePage = new HomePage(_context._driver);           
            _context.HomePage.NavigateTo(_context._driver);

        }

        [When(@"I click on the apply button")]
        public void WhenIClickOnTheApplyButton()
        {
            _context.ApplicationPage = _context.HomePage.ClickOnApplyButton();
        }

        [Then(@"I am on the application page")]
        public void ThenIAmOnTheApplicationPage()
        {
            _context.ApplicationPage.EnsurePageLoaded();
        }

        [Given(@"I click on the Next button on the right")]
        public void GivenIClickOnTheNextButtonOnTheRight()
        {
            _context.HomePage.ClickNextOnTheRight();
            Thread.Sleep(1000);
           
        }

        [When(@"I click on the 3rd apply button")]
        public void WhenIClickOn3RdApplyButton()
        {
            _context.ApplicationPage = _context.HomePage.ClickOnApplyButton3();
        }

        [When(@"I click on the random greeting link")]
        public void WhenIClickOnTheRandomGreetingLink()
        {
            _context.ApplicationPage = _context.HomePage.ClickOnRandomGreetingLink();
        }

        [Given(@"I wait for the Easy Application button to be visible")]
        public void GivenIWaitForTheEasyApplicationButtonToBeVisible()
        {
            _context.HomePage.WaitForEasyApplucationCarouselPage();
        }

        [When(@"I click on the Easy Application button")]
        public void WhenIClickOnTheEasyApplicationButton()
        {
            _context.ApplicationPage = _context.HomePage.ClickApplyEasyApplicationLink();
        }

        [Given(@"the initial generation token is visible")]
        public void GivenTheInitialGenerationTokenIsVisible()
        {
            this.ScenarioContext["initialToken"] = _context.HomePage.GenerationToken;
        }

        [Then(@"I am on Home page")]
        public void ThenIAmOnHomePage()
        {
            _context.HomePage.EnsurePageLoaded();
        }

        [Then(@"the generation token is different from the inital one")]
        public void ThenTheGenerationTokenIsDifferentFromTheInitalOne()
        {
            string initialToken = (string)this.ScenarioContext["initialToken"];
            Assert.NotEqual(initialToken, _context.HomePage.GenerationToken);
        }

        

    }
}
