using System;
using System.Collections.Generic;
using Captiva.Framework.Browser;
using Captiva.Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Captiva.Framework.Core
{
    public class Finder
    {
        public static IWebElement FindElement(WebElement element)
        {

            if (element.Container != null)
            {
                return element.FindElementFromHere(element.By);
            }

            return BrowserManager.Instance.Wait.Until(d => d.FindElement(element.By));
        }

        public static IReadOnlyCollection<IWebElement> FindElements(WebElement element)
        {
            if (element.Container != null)
            {
                return element.FindElementsFromHere(element.By);
            }

            return BrowserManager.Instance.Wait.Until(d => d.FindElements(element.By));
        }

        public static IWebElement TryFind(WebElement element)
        {

            var wait = new WebDriverWait(BrowserManager.Instance.Driver, TimeSpan.FromSeconds(2));

            if (element.Container != null)
            {
                return element.Container.Element.FindElementFromHere(element.By, 2, 2);
            }

            return wait.Until(d => d.FindElement(element.By));
        }
    }
}
