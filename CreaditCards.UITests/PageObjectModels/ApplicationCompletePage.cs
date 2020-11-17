using OpenQA.Selenium;
using Xunit;


namespace CreaditCards.UITests.PageObjectModels
{
     class ApplicationCompletePage : Page
    {
        protected override string PageUrl => "http://localhost:44108/Apply";
        protected override string PageTitle => "Application Complete - Credit Cards";
        public ApplicationCompletePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public string fullName => Driver.FindElement(By.CssSelector("#FullName")).Text;
        public void verifyFullName(string expectedFullName)
        {
            Assert.Equal(expectedFullName, fullName);
        }


    }
}
