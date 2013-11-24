using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace Selenium.Actions
{
    public static class KeyboardAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        public static void Insert(this IWebElement element, string key)
        {
            try
            {
                var wrappedElement = element as IWrapsDriver;
                var driver = wrappedElement.WrappedDriver;
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.KeyDown(key);
                action.KeyUp(key.ToString());
                action.Build().Perform();
            }
            catch { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="key"></param>
        public static void Insert(this IWebDriver driver, IWebElement element, string key)
        {
            try
            {
                var action = new OpenQA.Selenium.Interactions.Actions(driver);

                action.MoveToElement(element);
                action.KeyDown(key);
                action.KeyUp(key.ToString());
                action.Build().Perform();
            }
            catch { }
        }

    }
}
