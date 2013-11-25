using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Actions
{
    public static class KeyboardAction
    {
        /// <summary>
        /// Method performing specific key pressed.
        /// </summary>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="keystr"></param>
        public static void Insert(this IWebElement element, string keystr)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.KeyDown(keystr);
                action.KeyUp(keystr.ToString());
                action.Build().Perform();
            }
            catch { }
        }

        /// <summary>
        /// Method performing specific key pressed.
        /// </summary>
        /// <param name="driver">IWebDriver provided.</param>
        /// <param name="element">IWebElement element that receives the click action.</param>
        /// <param name="keystr"></param>
        public static void Insert(this IWebDriver driver, IWebElement element, string keystr)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.KeyDown(keystr);
                action.KeyUp(keystr);
                action.Build().Perform();
            }
            catch { }
        }
    }
}