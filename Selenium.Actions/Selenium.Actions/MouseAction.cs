using System;
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
        /// Method performing a mouse click on object with implicit driver.
        /// </summary>
        /// <param name="element">IWebElement element that receives the click action.</param>
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
        /// Method performing a mouse click on object with explicit driver.
        /// </summary>
        /// <param name="driver">IWebDriver provided.</param>
        /// <param name="element">IWebElement element that receives the click action.</param>
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
        /// Method performing a mouse click with hold. It's using the IWebElement element with implicit driver.
        /// </summary>
        /// <param name="element">IWebElement element that receives the click action.</param>
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
        /// Method performing a mouse click with hold and no release.
        /// </summary>
        /// <param name="driver">IWevDriver provided.</param>
        /// <param name="element">IWebElement element that receives the click and hold action.</param>
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
        /// Method performing a mouse right-click on a given IWebElement element.
        /// </summary>
        /// <param name="element">IWebElement element that receives the right-click action.</param>
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
        /// Method performing a mouse right-click on a given IWebElement element.
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
        /// Method performing a click on a given IWebElement element, and then waiting a given amount of time for another object to become visible.
        /// </summary>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="path">Path of element that needs to be visible after the mouse click action.</param>
        /// <param name="timespan">The maximum time to wait for the element to be visible.</param>
        public static void ClickAndWait(this IWebElement element, By path, int timespan = 5)
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

                wait.Until(ExpectedConditions.ElementExists(path));
                wait.Until(ExpectedConditions.ElementIsVisible(path));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, path,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// Method performing a click on a given IWebElement element, and then waiting a given amount of time for another object to become visible.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="path">Path of element that needs to be visible after the mouse click action.</param>
        /// <param name="timespan">The maximum time to wait for the element to be visible.</param>
        public static void ClickAndWait(this IWebDriver driver, IWebElement element, By path, int timespan = 5)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveToElement(element).Click();
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(path));
                wait.Until(ExpectedConditions.ElementIsVisible(path));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to click on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, path,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// Method performing a mouse click action on an IWebElement element and wait page with specific title.
        /// </summary>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="title">The new page title expected after click action.</param>
        /// <param name="timespan">The maximum time to wait for the page title.</param>
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
        /// Method performing a mouse click action on an IWebElement element and wait page with specific title.
        /// </summary>
        /// <param name="driver">IWebDriver provided.</param>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="title">The new page title expected after click action.</param>
        /// <param name="timespan">The maximum time to wait for the page title.</param>
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

        #endregion Click on objects

        #region Hover Actions

        /// <summary>
        /// Method is performing a mouse hover on a given IWebElement object.
        /// </summary>
        /// <param name="element">IWebElement element that receives the click action.</param>
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
        /// Method is performing a mouse hover on a given IWebElement object.
        /// </summary>
        /// <param name="driver">IWebDriver object provided.</param>
        /// <param name="element">IWebElement element that receives the click action.</param>
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
        /// Method is performing a mouse hover on a given IWebElement object, it then waits for specific length of time for a new IWebElement object to be visible given its path.
        /// </summary>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="path">Path of element that needs to be visible after the mouse hover action.</param>
        /// <param name="timespan">The maximum time to wait for the element to be visible.</param>
        public static void HoverAndWait(this IWebElement element, By path, int timespan = 5)
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

                wait.Until(ExpectedConditions.ElementExists(path));
                wait.Until(ExpectedConditions.ElementIsVisible(path));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to perform a mouse hover on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, path,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        /// <summary>
        /// Method is performing a mouse hover on a given IWebElement object, it then waits for specific length of time for a new IWebElement object to be visible given its path.
        /// </summary>
        /// <param name="driver">IWebDriver object provided.</param>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="path">Path of element that needs to be visible after the mouse hover action.</param>
        /// <param name="timespan">The maximum time to wait for the element to be visible.</param>
        public static void HoverAndWait(this IWebDriver driver, IWebElement element, By path, int timespan = 5)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));

                action.MoveToElement(element);
                action.MoveByOffset(1, 1);
                action.Build().Perform();

                wait.Until(ExpectedConditions.ElementExists(path));
                wait.Until(ExpectedConditions.ElementIsVisible(path));
            }
            catch (Exception e)
            {
                throw new InternalActionException(string.Format("Unable to perform a mouse hover on object \"{0}\" or wait for new object to be visible \"{1}\".\r\nSee:\r\n\t- {2}{3}", element, path,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        #endregion Hover Actions

        #region Drag & Drop

        /// <summary>
        /// Method performing a drag and drop of a given element onto another element (preferably a container).
        /// </summary>
        /// <param name="dragElement">Element to drag onto the drop element.</param>
        /// <param name="dropElement">The drop element (a container).</param>
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
        /// Method performing a drag and drop of a given element onto another element (preferably a container).
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="dragElement">Element to drag onto the drop element.</param>
        /// <param name="dropElement">The drop element (a container).</param>
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
                throw new InternalActionException(string.Format("Unable to drag object \"{0}\" onto drop area with object \"{1}\".\r\nSee:\r\n\t- {2}{3}", dragElement, dropElement,
                     e.Message, (e.InnerException == null ? "" : string.Format("\r\n\t- {0}", e.InnerException.Message))), e);
            }
        }

        #endregion Drag & Drop
    }
}