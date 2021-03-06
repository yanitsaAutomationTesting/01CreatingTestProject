﻿using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace CreaditCards.UITests.PageObjectModels
{
     class Page
    {
        protected IWebDriver Driver;
        protected virtual string PageUrl { get; }
        protected virtual string PageTitle { get; }

        public void NavigateTo(IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl(PageUrl);
            EnsurePageLoaded();
        }

        /// <summary>
        /// Checks that the URL and page title are as expected
        /// </summary>
        /// <param name="onlyCheckUrlStartsWithExpectedText">Set to false to do an exact match of URL. Set to true to ignore fragments, query string, etc at end of browser URL</param>
        public void EnsurePageLoaded(bool onlyCheckUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;
            if (onlyCheckUrlStartsWithExpectedText)
            {
                urlIsCorrect = Driver.Url.StartsWith(PageUrl);
            }
            else
            {
                urlIsCorrect = Driver.Url == PageUrl;
            }

            bool pageHasLoaded = urlIsCorrect && (Driver.Title == PageTitle);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }

        public void GoBackwards()
        {
            Driver.Navigate().Back();
        }

        public void SwitchToTabNumber(int tabNumber)
        {
            ReadOnlyCollection<string> allTabs = Driver.WindowHandles;
            string chosenTab = allTabs[tabNumber];
            Driver.SwitchTo().Window(chosenTab);
        }
    }
}
