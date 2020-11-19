
using OpenQA.Selenium;

namespace CreaditCards.UITests.PageObjectModels
{
    class ContactPage : Page
    {
        protected override string PageUrl => "http://localhost:44108/Home/Contact";
        protected override string PageTitle => "Contact - Credit Cards";

        public ContactPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
