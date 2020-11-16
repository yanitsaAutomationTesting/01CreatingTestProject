using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using CreaditCards.UITests.PageObjectModels;


namespace CreaditCards.UITests
{
    public class CreditCardWebAppShould
    {
        private const string AboutURL = "http://localhost:44108/Home/About";

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadHomePage()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                
            }
        }


        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);


                string initialToken = homePage.GenerationToken;

                driver.Navigate().GoToUrl(AboutURL);
                driver.Navigate().Back();

                homePage.EnsurePageLoaded();
               
                string reloadedToken = homePage.GenerationToken;
                Assert.NotEqual(initialToken, reloadedToken);
            }

        }


        [Fact]
        [Trait("Category", "Smoke")]
        public void DisplayProductsAndRates()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
               
                var homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                Assert.Equal("Easy Credit Card", homePage.Products[0].name);
                Assert.Equal("20% APR", homePage.Products[0].interestRate);

                Assert.Equal("Silver Credit Card", homePage.Products[1].name);
                Assert.Equal("18% APR", homePage.Products[1].interestRate);

                Assert.Equal("Gold Credit Card", homePage.Products[2].name);
                Assert.Equal("17% APR", homePage.Products[2].interestRate);


               
            }
        }


        [Fact]
        
        public void OpenContactFooterLinkInNewTab()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                homePage.ClickContactFooterLink();
                
                ReadOnlyCollection<string> allTabs = driver.WindowHandles;
                string homePageTab = allTabs[0];
                string contactTab = allTabs[1];

                driver.SwitchTo().Window(contactTab);
                Assert.Equal("http://localhost:44108/Home/Contact", driver.Url);
            }
        }


        [Fact]

        public void AlertIfLiveChatClosed()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);

                homePage.ClickLiveChatFooterLink();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                Assert.Equal("Live chat is currently closed.", alert.Text);
                alert.Accept();
               
            }
        }

        [Fact]

        public void NotNavigateToAboutUsOnCancel()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                homePage.ClickLearnAllAboutUsLink();
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                alert.Dismiss();
                homePage.EnsurePageLoaded();

            }
        }

        [Fact]
        public void NavigateToAboutUsWhenOKClicked()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                homePage.ClickLearnAllAboutUsLink();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                alert.Accept();
                Assert.EndsWith("/Home/About", driver.Url);
               

            }
        }



    }
}
