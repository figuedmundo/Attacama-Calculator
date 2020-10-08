using System.Collections.Generic;
using OpenQA.Selenium;

namespace Captiva.Framework.Core
{
    public class WebElement
    {
        public By By { get; set; }
        public string ControlName { get; set; }
        public WebElement Container { get; set; }

        public WebElement(Locator locator, string value, string controlName)
        {
            ControlName = controlName;
            By = SearchBy(locator, value);
        }

        public WebElement(WebElement container, Locator locator, string value, string controlName)
        {
            Container = container;
            ControlName = controlName;
            By = SearchBy(locator, value);
        }

        private IWebElement _element;

        public IWebElement Element
        {
            get
            {
                if (_element == null)
                {
                    _element = Finder.FindElement(this);
                }

                return _element;
            }
        }

        public IReadOnlyCollection<IWebElement> Elements
        {
            get
            {
                return Finder.FindElements(this);
            }
        }

        protected IWebElement TryFind()
        {
            return Finder.TryFind(this);
        }

        private By SearchBy(Locator locator, string value)
        {
            By by;
            switch (locator)
            {
                case Locator.Id:
                    by = By.Id(value);
                    break;
                case Locator.ClassName:
                    by = By.ClassName(value);
                    break;
                case Locator.CssSelector:
                    by = By.CssSelector(value);
                    break;
                case Locator.LinkText:
                    by = By.LinkText(value);
                    break;
                case Locator.Name:
                    by = By.Name(value);
                    break;
                case Locator.PartialLinkText:
                    by = By.PartialLinkText(value);
                    break;
                case Locator.TagName:
                    by = By.TagName(value);
                    break;
                case Locator.XPath:
                    by = By.XPath(value);
                    break;
                default:
                    by = null;
                    break;
            }

            return by;
        }
    }
}
