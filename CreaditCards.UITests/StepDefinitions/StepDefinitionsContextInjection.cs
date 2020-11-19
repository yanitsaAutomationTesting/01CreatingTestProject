

using CreaditCards.UITests.PageObjectModels;
using OpenQA.Selenium;

namespace CreaditCards.UITests.StepDefinitions
{
     class StepDefinitionsContextInjection
    {
        public HomePage HomePage { get; set; }
        public ApplicationPage ApplicationPage { get; set; }

        public ApplicationCompletePage ApplicationCompletePage { get; set; }

        public AboutPage AboutPage { get; set; }
        public ContactPage ContactPage { get; set; }
        public IWebDriver _driver { get; set; }
    }
}
