using CreaditCards.UITests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;
namespace CreaditCards.UITests.StepDefinitions
{
    [Binding]
   public class NavigateToApplicationPageStepDef : TechTalk.SpecFlow.Steps

    {
        private IWebDriver _driver;
        private HomePage homePage;
        private ApplicationPage applicationPage;
        private ApplicationCompletePage applicationCompletePage;
        private const string AboutURL = "http://localhost:44108/Home/About";


        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            _driver = new FirefoxDriver();
            homePage = new HomePage(_driver);
            homePage.NavigateTo(_driver);           
        }

        [When(@"I click on the apply button")]
        public void WhenIClickOnTheApplyButton()
        {
            applicationPage = homePage.ClickOnApplyButton();
        }

        [Then(@"I am on the application page")]
        public void ThenIAmOnTheApplicationPage()
        {
            applicationPage.EnsurePageLoaded();
        }

        [Given(@"I click on the Next button on the right")]
        public void GivenIClickOnTheNextButtonOnTheRight()
        {
            homePage.ClickNextOnTheRight();
            Thread.Sleep(1000);
           
        }

        [When(@"I click on the 3rd apply button")]
        public void WhenIClickOn3RdApplyButton()
        {
            applicationPage = homePage.ClickOnApplyButton3();
        }

        [When(@"I click on the random greeting link")]
        public void WhenIClickOnTheRandomGreetingLink()
        {
            applicationPage = homePage.ClickOnRandomGreetingLink();
        }

        [Given(@"I wait for the Easy Application button to be visible")]
        public void GivenIWaitForTheEasyApplicationButtonToBeVisible()
        {
            homePage.WaitForEasyApplucationCarouselPage();
        }

        [When(@"I click on the Easy Application button")]
        public void WhenIClickOnTheEasyApplicationButton()
        {
            applicationPage = homePage.ClickApplyEasyApplicationLink();
        }

        [Given(@"I enter first name (.*)")]
        public void GivenIEnterFirstNameSarah(string firstName)
        {
            applicationPage.EnterFirstName(firstName);
        }

        [Given(@"I enter last name (.*)")]
        public void GivenIEnterLastNameParker(string lastName)
        {
            applicationPage.EnterLastName(lastName);
        }

        [Given(@"I enter Frequent Flyer Number (.*)")]
        public void GivenIEnterFrequentFlyerNumber(string ffNumber)
        {
            applicationPage.EnterFrequentFlyerNumber(ffNumber);
        }

        [Given(@"I enter Age (.*)")]
        public void GivenIEnterAge(string age)
        {
            applicationPage.EnterAge(age);
        }

        [Given(@"I enter Gross Income (.*)")]
        public void GivenIEnterGrossIncome(string income)
        {
            applicationPage.EnterGrossIncome(income);
        }

        [Given(@"I select Relationship status (.*)")]
        public void GivenISelectRelationshipStatusMarried(string status)
        {
            applicationPage.ChooseMaritalStatus(status);
        }

        [Given(@"I select business source (.*)")]
        public void GivenISelectBusinessSource(string source)
        {
            applicationPage.ChooseBusinessSource(source);
        }

        [Given(@"I accept terms")]
        public void GivenIAcceptTerms()
        {
            applicationPage.AcceptTermsAndConditions();
        }

        [When(@"I click on the Submit Application button")]
        public void WhenIClickOnTheSubmitApplicationButton()
        {
            applicationCompletePage = applicationPage.SubmitApplication();
        }

        [When(@"I am on the Application Complete Page")]
        public void WhenIAmOnTheApplicationCompletePage()
        {
            applicationCompletePage.EnsurePageLoaded();
        }

        [Then(@"the full name is (.*)")]
        public void ThenTheFullNameIsSarahParker(string fullName)
        {
            applicationCompletePage.verifyFullName(fullName);
        }

        [Given(@"there are (.*) error messages")]
        public void GivenThereAreErrorMessages(int numberOfErrors)
        {
            Assert.Equal(numberOfErrors, applicationPage.ValidationMessages.Count);
        }

        [Given(@"validation for missing Last Name is displayed")]
        public void GivenValidationForMissingLastNameIsDisplayed()
        {
            Assert.Equal("Please provide a last name", applicationPage.ValidationMessages[0].ToString());
        }

        [Given(@"validation message for invalid age is displayed")]
        public void GivenValidationMessageForInvalidAgeIsDisplayed()
        {
            Assert.Equal("You must be at least 18 years old", applicationPage.ValidationMessages[1].ToString());
        }

        [Given(@"I clear the Age field")]
        public void GivenIClearTheAgeField()
        {
            applicationPage.ClearAge();
        }

        [Given(@"the initial generation token is visible")]
        public void GivenTheInitialGenerationTokenIsVisible()
        {
            this.ScenarioContext["initialToken"] = homePage.GenerationToken;
        }

        [Given(@"I go to the About page")]
        public void GivenIGoToTheAboutPage()
        {
            _driver.Navigate().GoToUrl(AboutURL);
        }

        [When(@"I go back")]
        public void WhenIGoBack()
        {
            _driver.Navigate().Back();
        }

        [Then(@"I am on Home page")]
        public void ThenIAmOnHomePage()
        {
            homePage.EnsurePageLoaded();
        }

        [Then(@"the generation token is different from the inital one")]
        public void ThenTheGenerationTokenIsDifferentFromTheInitalOne()
        {
            string initialToken = (string)this.ScenarioContext["initialToken"];
            Assert.NotEqual(initialToken, homePage.GenerationToken);
        }





        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }

    }
}
