using CreaditCards.UITests.PageObjectModels;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
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

        [Then(@"Product and Rates are:")]
        public void ThenProductAndRatesAre(Table table)
        {
            IEnumerable<dynamic> products = table.CreateDynamicSet();
            int i = 0;
            foreach (var product in products)
            {
                if (i < 3)
                {
                    Assert.Equal(product.productName, _context.HomePage.Products[i].name);
                    Assert.Equal(product.rate, _context.HomePage.Products[i].interestRate);
                    i++;
                } 
                

            }
        }


        [When(@"I click on the Contact link")]
        public void WhenIClickOnTheContactLink()
        {
            _context.ContactPage = _context.HomePage.ClickContactFooterLink();
        }

        [Then(@"the Contact page is loaded in a new tab")]
        public void ThenTheContactPageIsLoaded()
        {
            _context.HomePage.SwitchToTabNumber(1);
            Thread.Sleep(1000);
            _context.ContactPage.EnsurePageLoaded();
        }

        [When(@"I click on the Start Live Chat link")]
        public void WhenIClickOnTheStartLiveChatLink()
        {
            _context.HomePage.ClickLiveChatFooterLink();
        }

        [Then(@"the Alert pop-up is visible with text (.*) and accept it")]
        public void ThenTheAlertPop_UpIsVisible(string text)
        {
            _context.HomePage.VerifyAlertPopUpAndAccept(text);

        }

        [Then(@"the Alert pop-up is visible with text (.*) and close it")]
        public void ThenTheAlertPop_UpIsVisibleAndClose(string text)
        {

            _context.HomePage.VerifyAlertPopUpAndDismiss(text);
        }

        [When(@"I click on the All Aout Us link")]
        public void WhenIClickOnTheAllAoutUsLink()
        {
            _context.HomePage.ClickLearnAllAboutUsLink();
        }

        

        






    }
}
