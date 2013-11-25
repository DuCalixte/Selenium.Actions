using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Actions
{
    public static class CompositeAction
    {
        #region Multi Clicks

        #region SHIFT

        /// <summary>
        /// Method performing a multi-click selection given two IWebElement objects. Use on a list of objects, it should also select all elements found within the given objects.
        /// </summary>
        /// <param name="firstElement">First IWebElement object onto which first click is performed.</param>
        /// <param name="secondElement">Second IWebElement object onto which second click is performed.</param>
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
        /// Method performing a multi-click selection given two IWebElement objects. Use on a list of objects, it should also select all elements found within the given objects.
        /// </summary>
        /// <param name="driver">IWebDriver object to execute method.</param>
        /// <param name="firstElement">First IWebElement object onto which first click is performed.</param>
        /// <param name="secondElement">Second IWebElement object onto which second click is performed.</param>
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

        #endregion SHIFT

        #region CTRL

        /// <summary>
        /// Method performing a control click on multiple IWebElement objects.
        /// </summary>
        /// <param name="firstElement">First IWebElement object onto which first click is performed.</param>
        /// <param name="elements">The set of elements to perform the clicks.</param>
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
        /// Method performing a control click on multiple IWebElement objects.
        /// </summary>
        /// <param name="driver">IWebDriver object to execute method.</param>
        /// <param name="elements">The set of elements to perform the clicks.</param>
        public static void ControlClick(this IWebDriver driver, params IWebElement[] elements)
        {
            try
            {
                if (elements == null) return;
                if (elements.Length == 0) return;

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

        #endregion CTRL

        #endregion Multi Clicks
    }
}