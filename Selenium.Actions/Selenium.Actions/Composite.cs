using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Actions
{
    public static class Composite
    {
        #region Multi Clicks

        #region SHIFT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        public static void ShiftClick(this IWebElement firstElement, IWebElement secondElement)
        {
            try
            {
                var wrappedElement = firstElement as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(firstElement);
                action.MoveToElement(firstElement).Click();

                action.KeyDown(Keys.Shift);

                action.MoveToElement(secondElement);
                action.MoveToElement(secondElement).Click();

                action.KeyUp(Keys.Shift);
                action.Build().Perform();
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        public static void ShiftClick(this IWebDriver driver, IWebElement firstElement, IWebElement secondElement)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(firstElement);
                action.MoveToElement(firstElement).Click();

                action.KeyDown(Keys.Shift);

                action.MoveToElement(secondElement);
                action.MoveToElement(secondElement).Click();

                action.KeyUp(Keys.Shift);
                action.Build().Perform();
            }
            catch { }
        }

        #endregion

        #region CTRL

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="elements"></param>
        public static void ControlClick(this IWebElement firstElement, params IWebElement[] elements)
        {
            try
            {
                var wrappedElement = firstElement as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(firstElement);
                action.MoveToElement(firstElement).Click();

                action.KeyDown(Keys.Control);
                foreach (IWebElement element in elements)
                {
                    action.MoveToElement(element);
                    action.MoveToElement(element).Click();
                }
                action.KeyUp(Keys.Control);
                action.Build().Perform();
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="elements"></param>
        public static void ControlClick(this IWebDriver driver, params IWebElement[] elements)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.KeyDown(Keys.Control);
                foreach (IWebElement element in elements)
                {
                    action.MoveToElement(element);
                    action.MoveToElement(element).Click();
                }
                action.KeyUp(Keys.Control);
                action.Build().Perform();
            }
            catch { }
        }

        #endregion

        #endregion
    }
}
