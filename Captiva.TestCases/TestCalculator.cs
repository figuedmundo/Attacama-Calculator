using Captiva.TestCases.Base;
using NUnit.Framework;

namespace Captiva.TestCases
{
    public class TestCalculator : BaseTest
    {

        [Test]
        [TestCase("10", "10", "20")]
        [TestCase("-10", "-10", "-20")]
        [TestCase("0", "0", "0")]
        [TestCase("-1", "0", "-1")]
        [TestCase("0", "-1", "-1")]
        [TestCase("1", "0", "1")]
        [TestCase("0", "1", "1")]

        [TestCase("2", "-3", "-1")]
        [TestCase("3", "-2", "1")]
        [TestCase("-3", "2", "-1")]
        [TestCase("-2", "3", "1")]

        [TestCase("1073741824", "1073741823", "2147483647")]
        [TestCase("2147483647", "0", "2147483647")]
        [TestCase("-1", "-2147483647", "-2147483648")]

        [TestCase("1", "2147483647", "2147483648")]
        [TestCase("-2147483647", "-2", "-2147483649")]

        [TestCase("01", "0", "1")]
        [TestCase("0", "01", "1")]
        public void TestAddition(string val1, string val2, string expectedValue)
        {
            GoTo
             .MainPage
             .SetValue1(val1)
             .SetValue2(val2)
             .ClickCalculate()

             .MainPage
             .ValidateResult(expectedValue);
        }


        [Test]
        [TestCase("10", "10", "0")]
        [TestCase("-10", "-10", "0")]
        [TestCase("0", "0", "0")]
        [TestCase("-1", "0", "-1")]
        [TestCase("0", "-1", "1")]

        [TestCase("0", "1", "-1")]
        [TestCase("1", "0", "1")]

        [TestCase("2", "-3", "5")]
        [TestCase("3", "-2", "5")]
        [TestCase("-3", "2", "-5")]
        [TestCase("-2", "3", "-5")]

        [TestCase("1073741824", "1073741824", "0")]
        [TestCase("-1", "-2147483648", "2147483647")]
        [TestCase("-2147483647", "1", "-2147483648")]

        [TestCase("0", "-2147483648", "2147483648")]
        [TestCase("-2147483648", "1", "-2147483649")]
        public void TestSubtraction(string val1, string val2, string expectedValue)
        {
            GoTo
             .MainPage
             .SetValue1(val1)
             .SetValue2(val2)
             .SelectSubtraction()
             .ClickCalculate()

             .MainPage
             .ValidateResult(expectedValue);
        }

        [Test]
        [TestCase("10", "10", "100")]
        [TestCase("-10", "-10", "100")]
        [TestCase("0", "0", "0")]
        [TestCase("-1", "0", "0")]
        [TestCase("0", "-1", "0")]

        [TestCase("0", "1", "0")]
        [TestCase("1", "0", "0")]

        [TestCase("2", "-3", "-6")]
        [TestCase("3", "-2", "-6")]
        [TestCase("-3", "2", "-6")]
        [TestCase("-2", "3", "-6")]

        [TestCase("-1", "-2147483647", "2147483647")]
        [TestCase("-2147483648", "1", "-2147483648")]

        [TestCase("-1", "-2147483648", "2147483648")]
        [TestCase("1073741825", "-2", "-2147483650")]
        public void TestMultiplication(string val1, string val2, string expectedValue)
        {
            GoTo
             .MainPage
             .SetValue1(val1)
             .SetValue2(val2)
             .SelectMultiplication()
             .ClickCalculate()

             .MainPage
             .ValidateResult(expectedValue);
        }

        [Test]
        [TestCase("10", "10", "1")]
        [TestCase("-10", "-10", "1")]

        
        [TestCase("0", "1", "0")]
        [TestCase("0", "-1", "0")]

        [TestCase("1", "-1", "-1")]
        [TestCase("10", "-2", "-5")]
        [TestCase("-10", "2", "-5")]
        [TestCase("-1", "1", "-1")]

        [TestCase("2147483647", "1", "2147483647")]
        [TestCase("-2147483648", "1", "-2147483648")]
        public void TestDivision(string val1, string val2, string expectedValue)
        {
            GoTo
             .MainPage
             .SetValue1(val1)
             .SetValue2(val2)
             .SelectDivision()
             .ClickCalculate()

             .MainPage
             .ValidateResult(expectedValue);
        }

        [Test]
        [TestCase("2147483648", "0", "For input string: \"2147483648\"")]
        [TestCase("0", "2147483648", "For input string: \"2147483648\"")]

        [TestCase("-2147483649", "0", "For input string: \"-2147483649\"")]
        [TestCase("0", "-2147483649", "For input string: \"-2147483649\"")]

        [TestCase("", "0", "For input string: \"\"")]
        [TestCase("0", "", "For input string: \"\"")]

        [TestCase("abc", "0", "For input string: \"abc\"")]
        [TestCase("0", "xy", "For input string: \"xy\"")]

        //TestDivisionErrorMessage
        [TestCase("0", "0", "/ by zero")]
        [TestCase("1", "0", "/ by zero")]
        public void TestNegativeVal1AndVal2(string val1, string val2, string expectedValue)
        {
            GoTo
             .MainPage
             .SetValue1(val1)
             .SetValue2(val2)
             .SelectDivision()
             .ClickCalculate()

             .ErrorPage
             .ValidateErrorMessge(expectedValue);
        }
    }
}