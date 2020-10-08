using System;
using Captiva.Framework.Asserts;
using Captiva.Framework.Controls;
using Captiva.Framework.Core;

namespace Captiva.Framework.Pages.Calculator
{
    public class ErrorPage
    {
        public Control Message => new Control(Locator.XPath, "//p[./b[text()='Message']]", "Error Message");

        public ErrorPage ValidateErrorMessge(string expectedValue)
        {
            var actualValue = Message.GetText();
            AssertHandler.CompareStringsContains(expectedValue, actualValue, "Validate Error Message");

            return this;
        }
    }
}
