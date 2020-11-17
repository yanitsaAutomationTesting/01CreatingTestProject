
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace CreaditCards.UITests.StepDefinitions
{
    [Binding]
    class ApplicationPageSteps
    {
        private StepDefinitionsContextInjection _context;
        ApplicationPageSteps(StepDefinitionsContextInjection context)
        {
            _context = context;
        }


        [Given(@"I enter first name (.*)")]
        public void GivenIEnterFirstNameSarah(string firstName)
        {
            _context.ApplicationPage.EnterFirstName(firstName);
        }

        [Given(@"I enter last name (.*)")]
        public void GivenIEnterLastNameParker(string lastName)
        {
            _context.ApplicationPage.EnterLastName(lastName);
        }

        [Given(@"I enter Frequent Flyer Number (.*)")]
        public void GivenIEnterFrequentFlyerNumber(string ffNumber)
        {
            _context.ApplicationPage.EnterFrequentFlyerNumber(ffNumber);
        }

        [Given(@"I enter Age (.*)")]
        public void GivenIEnterAge(string age)
        {
            _context.ApplicationPage.EnterAge(age);
        }

        [Given(@"I enter Gross Income (.*)")]
        public void GivenIEnterGrossIncome(string income)
        {
            _context.ApplicationPage.EnterGrossIncome(income);
        }

        [Given(@"I select Relationship status (.*)")]
        public void GivenISelectRelationshipStatusMarried(string status)
        {
            _context.ApplicationPage.ChooseMaritalStatus(status);
        }

        [Given(@"I select business source (.*)")]
        public void GivenISelectBusinessSource(string source)
        {
            _context.ApplicationPage.ChooseBusinessSource(source);
        }

        [Given(@"I accept terms")]
        public void GivenIAcceptTerms()
        {
            _context.ApplicationPage.AcceptTermsAndConditions();
        }

        [When(@"I click on the Submit Application button")]
        public void WhenIClickOnTheSubmitApplicationButton()
        {
            _context.ApplicationCompletePage = _context.ApplicationPage.SubmitApplication();
        }

        [Given(@"there are (.*) error messages")]
        public void GivenThereAreErrorMessages(int numberOfErrors)
        {
            Assert.Equal(numberOfErrors, _context.ApplicationPage.ValidationMessages.Count);
        }

        [Given(@"validation for missing Last Name is displayed")]
        public void GivenValidationForMissingLastNameIsDisplayed()
        {
            Assert.Equal("Please provide a last name", _context.ApplicationPage.ValidationMessages[0].ToString());
        }

        [Given(@"validation message for invalid age is displayed")]
        public void GivenValidationMessageForInvalidAgeIsDisplayed()
        {
            Assert.Equal("You must be at least 18 years old", _context.ApplicationPage.ValidationMessages[1].ToString());
        }

        [Given(@"I clear the Age field")]
        public void GivenIClearTheAgeField()
        {
            _context.ApplicationPage.ClearAge();
        }




    }
}
