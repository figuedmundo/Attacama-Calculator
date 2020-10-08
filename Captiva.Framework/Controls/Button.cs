using System.Threading;
using Captiva.Framework.Browser;
using Captiva.Framework.Core;
using Captiva.Reports;

namespace Captiva.Framework.Controls
{
    public class Button : Control
    {
        public Button(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }

        public Button(WebElement container, Locator locator, string value, string controlName) :
            base(container, locator, value, controlName)
        {
        }

        public void Click()
        {
            Element.Click();
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Button has been clicked.");
        }

        public void Hover()
        {
            BrowserManager.Instance.Actions
                .MoveToElement(Element)
                .Perform();

            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Button has been hovered.");
        }
    }
}

