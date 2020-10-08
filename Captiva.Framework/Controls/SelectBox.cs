using System.Linq;
using Captiva.Framework.Core;
using Captiva.Reports;
using OpenQA.Selenium.Support.UI;

namespace Captiva.Framework.Controls
{
    public class SelectBox : Control
    {
        private readonly SelectElement SelectWebElement;

        public SelectBox(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
            SelectWebElement = new SelectElement(Element);
        }

        public string GetOptionSelected()
        {
            var option = SelectWebElement.SelectedOption;
            var res = option.Text;
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Select has the option [{res}] selected.");

            return res;
        }

        public void SelectByText(string text)
        {
            SelectWebElement.SelectByText(text);
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Select has selected the option [{text}].");
        }
    }
}

