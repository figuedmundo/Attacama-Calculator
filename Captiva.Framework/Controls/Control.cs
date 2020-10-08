using System;
using System.Diagnostics;
using Captiva.Framework.Browser;
using Captiva.Framework.Core;
using Captiva.Reports;
using OpenQA.Selenium;

namespace Captiva.Framework.Controls
{
    public class Control : WebElement
    {
        public Control(Locator locator, string value, string controlName)
            : base(locator, value, controlName)
        {
        }

        public Control(WebElement container, Locator locator, string value, string controlName) :
            base(container, locator, value, controlName)
        {
        }

        public string GetText()
        {
            var text = Element.Text;
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Control contains the text [{text}]");
            return text;
        }

        public bool IsDisplayed()
        {
            var res = Element.Displayed;
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Control is displayed.");

            return res;
        }

        public bool IsEnable()
        {
            var res = Element.Enabled;
            var message = res ? "enabled" : "disabled";
            ReportManager.Instance.SetStepStatusPass($"[{ControlName}] Control is {message}.");

            return res;
        }

        public bool IsPresent()
        {
            try
            {
                return TryFind() != null ;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Highlight()
        {
            try
            {
                var jsDriver = (IJavaScriptExecutor)BrowserManager.Instance.Driver;
                const string highlightJavascript =
                    @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: blue"";";

                var originalElementBorder = (string)jsDriver.ExecuteScript(highlightJavascript, Element);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Element {ControlName} cannot be Hihglighted, Exception [{ex.Message}]");
            }
        }

        public void VerifyContainsText(string expectedValue)
        {
            var text = GetText();

            if (!text.Contains(expectedValue, StringComparison.InvariantCultureIgnoreCase))
            {
                var message = $"[{ControlName}]: Failed, Text [{text}], expected to contains [{expectedValue}]";
                throw new InvalidElementStateException(message);
            }
        }
    }
}

