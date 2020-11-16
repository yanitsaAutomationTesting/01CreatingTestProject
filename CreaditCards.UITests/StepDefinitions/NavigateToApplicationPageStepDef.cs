using CreaditCards.UITests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CreaditCards.UITests.StepDefinitions
{
    [Binding]
   public class NavigateToApplicationPageStepDef
    {
        private IWebDriver _driver;
        private HomePage homePage;
        private ApplicationPage applicationPage;
        private ApplicationCompletePage applicationCompletePage;


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
            applicationPage = homePage.clickOnApplyButton();
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
            applicationPage = homePage.clickOnApplyButton3();
        }

        [When(@"I click on the random greeting link")]
        public void WhenIClickOnTheRandomGreetingLink()
        {
            applicationPage = homePage.clickOnRandomGreetingLink();
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
            applicationPage.enterFirstName(firstName);
        }

        [Given(@"I enter last name (.*)")]
        public void GivenIEnterLastNameParker(string lastName)
        {
            applicationPage.enterLastName(lastName);
        }

        [Given(@"I enter Frequent Flyer Number (.*)")]
        public void GivenIEnterFrequentFlyerNumber(string ffNumber)
        {
            applicationPage.enterFrequentFlyerNumber(ffNumber);
        }

        [Given(@"I enter Age (.*)")]
        public void GivenIEnterAge(string age)
        {
            applicationPage.enterAge(age);
        }

        [Given(@"I enter Gross Income (.*)")]
        public void GivenIEnterGrossIncome(string income)
        {
            applicationPage.enterGrossIncome(income);
        }

        [Given(@"I select Relationship status (.*)")]
        public void GivenISelectRelationshipStatusMarried(string status)
        {
            applicationPage.chooseMaritalStatus(status);
        }

        [Given(@"I select business source (.*)")]
        public void GivenISelectBusinessSource(string source)
        {
            applicationPage.chooseBusinessSource(source);
        }

        [Given(@"I accept terms")]
        public void GivenIAcceptTerms()
        {
            applicationPage.acceptTermsAndConditions();
        }

        [When(@"I click on the Submit Application button")]
        public void WhenIClickOnTheSubmitApplicationButton()
        {
            applicationCompletePage = applicationPage.submitApplication();
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




        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }

    }
}
