
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using OpenQA.Selenium.Support.UI;

namespace CreaditCards.UITests.PageObjectModels
{
     class HomePage : Page
    {
        protected override string PageUrl => "http://localhost:44108/";
        protected override string PageTitle => "Home Page - Credit Cards";
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }
        //getter for GenerationToken property returning its text
        public string GenerationToken => Driver.FindElement(By.Id("GenerationToken")).Text;
        public void ClickContactFooterLink() => Driver.FindElement(By.CssSelector("#ContactFooter")).Click();

        

        public ReadOnlyCollection<(string name, string interestRate)> Products
        {
            get
            {
                var products = new List<(string name, string interestRate)>();
                var productCells = Driver.FindElements(By.TagName("td"));
                
                for (int i = 0; i< productCells.Count - 1; i += 2)
                {
                    string name = productCells[i].Text;
                    string interestRate = productCells[i + 1].Text;
                    products.Add((name, interestRate));
                }return products.AsReadOnly();
            }
        }

        

        

       public void ClickLiveChatFooterLink() => Driver.FindElement(By.CssSelector("#LiveChat")).Click();
        public void ClickLearnAllAboutUsLink() => Driver.FindElement(By.CssSelector("#LearnAboutUs")).Click();
        public ApplicationPage  ClickOnApplyButton()
        {
            Driver.FindElement(By.Name("ApplyLowRate")).Click();
            return new ApplicationPage(Driver);
        }
        public ApplicationPage ClickOnApplyButton3()
        {   
            Driver.FindElement(By.ClassName("customer-service-apply-now")).Click();
            return new ApplicationPage(Driver);
        }
        public ApplicationPage ClickOnRandomGreetingLink()
        {
            Driver.FindElement(By.PartialLinkText("- Apply Now")).Click();
            return new ApplicationPage(Driver);
        }

       public void WaitForEasyApplucationCarouselPage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(12));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Easy: Apply Now!")));

        }

        public ApplicationPage ClickApplyEasyApplicationLink()
        {
            Driver.FindElement(By.LinkText("Easy: Apply Now!")).Click();
            return new ApplicationPage(Driver);
        }

        public void ClickNextOnTheRight() => Driver.FindElement(By.CssSelector(".glyphicon-chevron-right")).Click();

                


    }
}
