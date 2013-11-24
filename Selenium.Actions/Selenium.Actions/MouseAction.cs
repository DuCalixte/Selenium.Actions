using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Actions
{
    /// <summary>
    /// MouseAction extends Selenium, Selenium.Internal by providing alternative methods for mouse clicks and other mouse interactions.
    /// These methods work with all major browsers supported by Selenium. 
    /// </summary>
    public static class MouseAction
    {
        #region Click on objects

        /// <summary>
        /// Alternative method for performing click on object with implicit driver.
        /// </summary>
        /// <param name="element">A IWebElement object, also utilized to create a new driver instance</param>
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
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// Alternative method for performing click on object with explicit driver.
        /// </summary>
        /// <param name="driver">IWevDriver provided.</param>
        /// <param name="element">IWebElement for the click.</param>
        public static void Click(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
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
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click and hold object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver">IWevDriver provided.</param>
        /// <param name="element">IWebElement for the click.</param>
        public static void ClickAndHold(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).ClickAndHold();
                action.Build().Perform();
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click and hold object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
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
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to right-click on object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver">IWevDriver provided.</param>
        /// <param name="element">IWebElement for the click.</param>
        public static void ContextClick(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveToElement(element).ContextClick();
                action.Build().Perform();
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to right-click on object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="otherElement"></param>
        /// <param name="timespan"></param>
        public static void ClickAndWait(this IWebElement element, By otherElement, int timespan = 5)
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

                wait.Until(ExpectedConditions.ElementExists(otherElement));
                wait.Until(ExpectedConditions.ElementIsVisible(otherElement));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, otherElement,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="otherElement"></param>
        /// <param name="timespan"></param>
        public static void ClickAndWait(this IWebDriver driver, IWebElement element, By otherElement, int timespan = 5)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(otherElement));
                wait.Until(ExpectedConditions.ElementIsVisible(otherElement));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, otherElement,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="title"></param>
        /// <param name="timespan"></param>
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
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\" or wait for new title \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, title,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="title"></param>
        /// <param name="timespan"></param>
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
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\" or wait for new title \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, title,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        #endregion

        #region Hover Actions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
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
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to perform a mouse hover on object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void Hover(this IWebDriver driver, IWebElement element)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.MoveByOffset(1, 1);
                action.Build().Perform();
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to perform a mouse hover on object \"{0}\".\r\nSee:\r\n\t- {1}{2}", element,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="otherElement"></param>
        /// <param name="timespan"></param>
        public static void HoverAndWait(this IWebElement element, By otherElement, int timespan = 5)
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

                wait.Until(ExpectedConditions.ElementExists(otherElement));
                wait.Until(ExpectedConditions.ElementIsVisible(otherElement));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to perform a mouse hover on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, otherElement,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="otherElement"></param>
        /// <param name="timespan"></param>
        public static void HoverAndWait(this IWebDriver driver, IWebElement element, By otherElement, int timespan = 5)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveByOffset(1, 1);
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(otherElement));
                wait.Until(ExpectedConditions.ElementIsVisible(otherElement));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to perform a mouse hover on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, otherElement,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        #endregion

        #region Drag & Drop

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dragElement"></param>
        /// <param name="dropElement"></param>
        public static void DragAndDrop(this IWebElement dragElement, IWebElement dropElement)
        {
            try
            {
                var wrappedElement = dragElement as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(dragElement).Build().Perform();
                action.MoveToElement(dragElement).ClickAndHold();
                action.MoveToElement(dropElement).Release(dropElement);
                action.Build().Perform();
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to drag object \"{0}\" onto drop area with object \"{1}\".\r\nSee:\r\n\t- {2}{3}", dragElement, dropElement,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="dragElement"></param>
        /// <param name="dropElement"></param>
        public static void DragAndDrop(this IWebDriver driver, IWebElement dragElement, IWebElement dropElement)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(dragElement).Build().Perform();
                action.MoveToElement(dragElement).ClickAndHold();
                action.MoveToElement(dropElement).Release(dropElement);
                action.Build().Perform();
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to drag object \"{0}\" onto drop area with object \"{1}\".\r\nSee:\r\n\t- {2}{3}", dragElement,dropElement,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        #endregion
    }
}
