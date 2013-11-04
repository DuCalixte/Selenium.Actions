using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Actions
{
    public static class Mouse
    {
        #region Click on objects

        public static void Click(this IWebElement element)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();
            }
            catch { }
        }

        public static void Click(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();
            }
            catch { }
        }

        public static void ClickAndHold(this IWebElement element)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).ClickAndHold();
                action.Build().Perform();
            }
            catch { }
        }

        public static void ClickAndHold(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).ClickAndHold();
                action.Build().Perform();
            }
            catch { }
        }

        public static void ContextClick(this IWebElement element)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).ContextClick();
                action.Build().Perform();
            }
            catch { }
        }

        public static void ContextClick(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).ContextClick();
                action.Build().Perform();
            }
            catch { }
        }

        public static void ClickAndWait(this IWebElement element, By newObject, int timespan = 5)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(newObject));
                wait.Until(ExpectedConditions.ElementIsVisible(newObject));
            }
            catch { }
        }

        public static void ClickAndWait(this IWebDriver driver, IWebElement element, By newObject, int timespan = 5)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(newObject));
                wait.Until(ExpectedConditions.ElementIsVisible(newObject));
            }
            catch { }
        }

        public static void ClickAndWait(this IWebElement element, string title, int timespan = 5)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();

                wait.Until(d => d.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
            }
            catch { }
        }

        public static void ClickAndWait(this IWebDriver driver, IWebElement element, string title, int timespan = 5)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();

                wait.Until(d => d.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
            }
            catch { }
        }

        #endregion

        #region Hover Actions

        public static void Hover(this IWebElement element)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveByOffset(1, 1);
                action.Build().Perform();
            }
            catch { }
        }

        public static void Hover(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveByOffset(1, 1);
                action.Build().Perform();
            }
            catch { }
        }

        public static void HoverAndWait(this IWebElement element, By newObject, int timespan = 5)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveByOffset(1, 1);
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(newObject));
                wait.Until(ExpectedConditions.ElementIsVisible(newObject));
            }
            catch { }
        }

        public static void HoverAndWait(this IWebDriver driver, IWebElement element, By newObject, int timespan = 5)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveByOffset(1, 1);
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(newObject));
                wait.Until(ExpectedConditions.ElementIsVisible(newObject));
            }
            catch { }
        }

        #endregion
    }
}
