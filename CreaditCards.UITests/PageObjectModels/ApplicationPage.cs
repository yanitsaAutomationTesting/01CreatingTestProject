using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace CreaditCards.UITests.PageObjectModels
{
     class ApplicationPage : Page
    {


        protected override string PageUrl => "http://localhost:44108/Apply";
        protected override string PageTitle => "Credit Card Application - Credit Cards";

        public ApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public ReadOnlyCollection<string> ValidationMessages
        {
            get
            {
                return Driver.FindElements(By.CssSelector(".validation-summary-errors > ul > li")).Select(x => x.Text).ToList().AsReadOnly();
            }
        }

        public void ClearAge() => Driver.FindElement(By.Id("Age")).Clear();
        public void EnterFirstName(string name) => Driver.FindElement(By.CssSelector("#FirstName")).SendKeys(name);
        public void EnterLastName(string lastName) => Driver.FindElement(By.CssSelector("#LastName")).SendKeys(lastName);
        public void EnterAge(string age) => Driver.FindElement(By.CssSelector("#Age")).SendKeys(age);
        public void EnterFrequentFlyerNumber(string ffNumber) => Driver.FindElement(By.CssSelector("#FrequentFlyerNumber")).SendKeys(ffNumber);
        public void EnterGrossIncome(string grossIncome) => Driver.FindElement(By.CssSelector("[name='GrossAnnualIncome']")).SendKeys(grossIncome);
        public void ChooseMaritalStatus(string maritalStatus)
        {
            if(maritalStatus == "Married")
            {
                Driver.FindElement(By.CssSelector("#Married")).Click();
            }
            else if(maritalStatus == "De facto")
            {
                Driver.FindElement(By.CssSelector("#Defacto")).Click();
            }
            else if(maritalStatus == "Single")
            {
                Driver.FindElement(By.CssSelector("#Single")).Click();
            }else
            {
                throw new Exception("You maybe did not specify the correct Marital Status - Married, De facto, Single");
            }

        }

        public void VerifyBusinessSourceDropdownOptions()
        {
            IWebElement businessSourceDropdown = Driver.FindElement(By.CssSelector("#BusinessSource"));
            SelectElement businessSourceSelect = new SelectElement(businessSourceDropdown);

            IList<IWebElement> actualBusSourceValues = businessSourceSelect.Options;
            List<string> expectedBusSourceValues = new List<string>() { "I'd Rather Not Say", "Internet Search", "Marketing Email", "Word of Mouth", "TV Ad" };

            IWebElement firstOption = actualBusSourceValues[0];
            IWebElement secondOption = actualBusSourceValues[1];
            IWebElement thirdOption = actualBusSourceValues[2];
            IWebElement forthOption = actualBusSourceValues[3];
            IWebElement fifthOption = actualBusSourceValues[4];

            Assert.Equal(expectedBusSourceValues[0], firstOption.Text);
            Assert.Equal(expectedBusSourceValues[1], secondOption.Text);
            Assert.Equal(expectedBusSourceValues[2], thirdOption.Text);
            Assert.Equal(expectedBusSourceValues[3], forthOption.Text);
            Assert.Equal(expectedBusSourceValues[4], fifthOption.Text);
            //count the options

            Assert.Equal(5, businessSourceSelect.Options.Count);
        }
        
        public void ChooseBusinessSource(string source)
        {
            IWebElement businessSourceDropdown = Driver.FindElement(By.CssSelector("#BusinessSource"));
            SelectElement businessSourceSelect = new SelectElement(businessSourceDropdown);
            businessSourceSelect.SelectByText(source);
        }

        public void AcceptTermsAndConditions()
        {
            Driver.FindElement(By.CssSelector("[type='checkbox'][name='TermsAccepted']")).Click();
        }

        public ApplicationCompletePage SubmitApplication() 
        { 
            Driver.FindElement(By.CssSelector("#SubmitApplication")).Click();
            return new ApplicationCompletePage(Driver);
        }
     











    } 

    }
