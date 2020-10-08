using Captiva.Framework.Core;
using Captiva.Reports;

namespace Captiva.Framework.Controls
{
    public class TextBox : Control
    {
        public TextBox(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }

        public TextBox(WebElement container, Locator locator, string value, string controlName) :
            base(container, locator, value, controlName)
        {
        }

        public void Clear()
        {
            Element.Clear();
        }

        public void SetText(string text)
        {
            Clear();
            Element.SendKeys(text);
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] TextBox has set text [{text}]");
        }

        public new string GetText()
        {
            return Element.GetAttribute("value").ToString();
        }
    }
}

