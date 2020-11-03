using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;
using System.Threading;
using CreaditCards.UITests.PageObjectModels;


namespace CreaditCards.UITests
{
    public class CreditCardApplicationShould
    {
        private const string HomeUrl = "http://localhost:44108/";
        private const string ApplyUrl = "http://localhost:44108/Apply";
        
        

        [Fact]
        public void BeInitiatedFromHomePage_NewLowRate()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo();
                
                ApplicationPage applicationPage = homePage.clickOnApplyButton();
                applicationPage.EnsurePageLoaded();
            }
        }


        [Fact]
        public void BeInitiatedFromHomePage_CustomerService()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.Navigate().GoToUrl(HomeUrl);
                IWebElement nextGoToRight = driver.FindElement(By.CssSelector(".glyphicon-chevron-right"));
                nextGoToRight.Click();
                Thread.Sleep(1000);
                IWebElement applyLink = driver.FindElement(By.CssSelector(".active [href='/Apply']"));
                nextGoToRight.Click();
                Thread.Sleep(1000);
                IWebElement applyLink3 = driver.FindElement(By.ClassName("customer-service-apply-now"));
                applyLink3.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);

            }
        }

        [Fact]
        public void BeInitiatedFromHomePage_RandomGreeting()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                Thread.Sleep(1000);

                IWebElement randomGreeting = driver.FindElement(By.PartialLinkText("- Apply Now"));
                Thread.Sleep(1000);
                randomGreeting.Click();
                Assert.Equal("Credit Card Application - Credit Cards", driver.Title);
                Assert.Equal(ApplyUrl, driver.Url);
            }
        }


        [Fact]
        public void BeInitiatedFromHomePage_EasyApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo();
                homePage.WaitForEasyApplucationCarouselPage();
                ApplicationPage applicationPage = homePage.ClickApplyEasyApplicationLink();
                applicationPage.EnsurePageLoaded();
               
            }
        }

        [Fact]
        public void BeSubmittedWhenValid()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                ApplicationPage applicationPage = new ApplicationPage(driver);
                applicationPage.NavigateTo();
                applicationPage.enterFirstName("Sarah");
                applicationPage.enterLastName("Parker");
                applicationPage.enterFrequentFlyerNumber("45556");
                applicationPage.enterAge("20");
                applicationPage.enterGrossIncome("10000");
                applicationPage.chooseMaritalStatus("Single");
                applicationPage.chooseBusinessSource("Internet Search");
                applicationPage.acceptTermsAndConditions();
                ApplicationCompletePage applicationCompletePage = applicationPage.submitApplication();

                //check we are on the Complete application page
                applicationCompletePage.EnsurePageLoaded();
                //verify the data we entered
                Assert.Equal("Sarah Parker", applicationCompletePage.fullName);
                
            }
        }





        [Fact]
        public void BeSubmittedWhenValidationErrorsCorrected()
        {
            const string firstName = "Sarah";
            const string invalidAge = "17";
            const string validAge = "18";

            using (IWebDriver driver = new FirefoxDriver())
            {
                ApplicationPage applicationPage = new ApplicationPage(driver);
                applicationPage.NavigateTo();

                applicationPage.enterFirstName(firstName);
                // Don't enter lastname
                applicationPage.enterFrequentFlyerNumber("45556");
                applicationPage.enterAge(invalidAge);
                applicationPage.enterGrossIncome("10000");
                applicationPage.chooseMaritalStatus("Single");
                applicationPage.chooseBusinessSource("Internet Search");
                applicationPage.acceptTermsAndConditions();
                applicationPage.submitApplication();

                // Assert that validation failed                
                Assert.Equal(2, applicationPage.ValidationMessages.Count);
                Assert.Equal("Please provide a last name", applicationPage.ValidationMessages[0].ToString());
                Assert.Equal("You must be at least 18 years old", applicationPage.ValidationMessages[1].ToString());

                // Fix errors
                applicationPage.enterLastName("Parker");
                applicationPage.ClearAge();
                applicationPage.enterAge(validAge);

                driver.FindElement(By.Id("Age")).SendKeys(validAge);

                // Resubmit form
                ApplicationCompletePage applicationCompletePage = applicationPage.submitApplication();

                // Check form submitted
                applicationCompletePage.EnsurePageLoaded();
                Assert.Equal("Sarah Parker", applicationCompletePage.fullName);
            }
        }
















        }
}
