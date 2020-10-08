using System;
using Captiva.Framework.Core;
using Captiva.Reports;

namespace Captiva.Framework.Controls
{
    public class RadioButton : Control
    {

        public RadioButton(Locator locator, string value, string controlName) :
            base(locator, value, controlName)
        {
        }

        public void Check()
        {
            Element.Click();
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Radio Buton has been checked.");
        }
    }
}
