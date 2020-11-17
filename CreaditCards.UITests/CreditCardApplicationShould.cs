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
        
        [Fact]
        public void BeInitiatedFromHomePage_NewLowRate()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                
                ApplicationPage applicationPage = homePage.ClickOnApplyButton();
                applicationPage.EnsurePageLoaded();
            }
        }


        [Fact]
        public void BeInitiatedFromHomePage_CustomerService()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                homePage.ClickNextOnTheRight();
                Thread.Sleep(1000);
                homePage.ClickNextOnTheRight();
                Thread.Sleep(1000);
                ApplicationPage applicationPage = homePage.ClickOnApplyButton3();
                applicationPage.EnsurePageLoaded();
                

            }
        }

        [Fact]
        public void BeInitiatedFromHomePage_RandomGreeting()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
                ApplicationPage applicationPage = homePage.ClickOnRandomGreetingLink();
                applicationPage.EnsurePageLoaded();

            }
        }


        [Fact]
        public void BeInitiatedFromHomePage_EasyApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                HomePage homePage = new HomePage(driver);
                homePage.NavigateTo(driver);
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
                applicationPage.NavigateTo(driver);
                applicationPage.EnterFirstName("Sarah");
                applicationPage.EnterLastName("Parker");
                applicationPage.EnterFrequentFlyerNumber("45556");
                applicationPage.EnterAge("20");
                applicationPage.EnterGrossIncome("10000");
                applicationPage.ChooseMaritalStatus("Single");
                applicationPage.ChooseBusinessSource("Internet Search");
                applicationPage.AcceptTermsAndConditions();
                ApplicationCompletePage applicationCompletePage = applicationPage.SubmitApplication();

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
                applicationPage.NavigateTo(driver);

                applicationPage.EnterFirstName(firstName);
                // Don't enter lastname
                applicationPage.EnterFrequentFlyerNumber("45556");
                applicationPage.EnterAge(invalidAge);
                applicationPage.EnterGrossIncome("10000");
                applicationPage.ChooseMaritalStatus("Single");
                applicationPage.ChooseBusinessSource("Internet Search");
                applicationPage.AcceptTermsAndConditions();
                applicationPage.SubmitApplication();

                // Assert that validation failed                
                Assert.Equal(2, applicationPage.ValidationMessages.Count);
                Assert.Equal("Please provide a last name", applicationPage.ValidationMessages[0].ToString());
                Assert.Equal("You must be at least 18 years old", applicationPage.ValidationMessages[1].ToString());

                // Fix errors
                applicationPage.EnterLastName("Parker");
                applicationPage.ClearAge();
                applicationPage.EnterAge(validAge);

                driver.FindElement(By.Id("Age")).SendKeys(validAge);

                // Resubmit form
                ApplicationCompletePage applicationCompletePage = applicationPage.SubmitApplication();

                // Check form submitted
                applicationCompletePage.EnsurePageLoaded();
                Assert.Equal("Sarah Parker", applicationCompletePage.fullName);
            }
        }
















        }
}
