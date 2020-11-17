using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaditCards.UITests.PageObjectModels
{
    class AboutPage : Page
    {
        protected override string PageUrl => "http://localhost:44108/Home/About";

        protected override string PageTitle => "About - Credit Cards";

        public AboutPage(IWebDriver driver)
        {
            Driver = driver;
        }
        
    }
}
