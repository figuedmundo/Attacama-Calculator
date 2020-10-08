using System;
using Captiva.Framework.Asserts;
using Captiva.Framework.Controls;
using Captiva.Framework.Core;

namespace Captiva.Framework.Pages.Calculator
{
    public class MainPage
    {
        public MainPage()
        {

        }
        private TextBox Value1 => new TextBox(Locator.Name, "val1", "Value 1");
        private TextBox Value2 => new TextBox(Locator.Name, "val2", "Value 2");
        private RadioButton Addition => new RadioButton(Locator.CssSelector,
            "input[type='radio'][value='add']", "Addition");
        private RadioButton Subtraction => new RadioButton(Locator.CssSelector,
            "input[type='radio'][value='sub']", "Subtraction");
        private RadioButton Multiplication => new RadioButton(Locator.CssSelector,
            "input[type='radio'][value='mul']", "Multiplication");
        private RadioButton Division => new RadioButton(Locator.CssSelector,
            "input[type='radio'][value='div']", "Division");
        private Button Calculate => new Button(Locator.CssSelector,
            "input[type='submit'][value='Calculate']", "Calculate");
        private TextBox Result => new TextBox(Locator.Name, "result", "Result");

        public MainPage SetValue1(string number)
        {
            Value1.SetText(number);
            return this;
        }

        public MainPage SetValue2(string number)
        {
            Value2.SetText(number);
            return this;
        }

        public MainPage SelectAddition()
        {
            Addition.Check();
            return this;
        }

        public MainPage SelectSubtraction()
        {
            Subtraction.Check();
            return this;
        }

        public MainPage SelectMultiplication()
        {
            Multiplication.Check();
            return this;
        }

        public MainPage SelectDivision()
        {
            Division.Check();
            return this;
        }

        public FromMainPageTo ClickCalculate()
        {
            Calculate.Click();
            return new FromMainPageTo();
        }

        public MainPage ValidateResult(string expectedValue)
        {
            var actualValue = Result.GetText();
            AssertHandler.CompareStringsEquals(expectedValue, actualValue, "Validate the Result");
            return this;
        }
    }

    public class FromMainPageTo
    {
        public MainPage MainPage => new MainPage();
        public ErrorPage ErrorPage => new ErrorPage();
    }
}
