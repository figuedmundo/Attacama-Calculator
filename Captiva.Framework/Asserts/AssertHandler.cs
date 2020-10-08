using System;
using System.Collections.Generic;
using Captiva.Reports;
using NUnit.Framework;

namespace Captiva.Framework.Asserts
{
    public class AssertHandler
    {
        public static void CompareStringInList(string expectedString, ICollection<string> list)
        {
            foreach (var text in list)
            {
                if (text.Contains(expectedString, StringComparison.InvariantCultureIgnoreCase))
                {
                    ReportManager.Instance.SetStepStatusPass($"[{text}] contains [{expectedString}]");
                }
                else
                {
                    throw new AssertionException(
                        $"Test Failed due option not in list:" +
                        $"Actual Text: [{text}] " +
                        $"\nExpected Tex: [{expectedString}]");
                }
            }
        }

        public static void CompareStringsContains(string expectedValue, string actualValue, string message)
        {
            if (actualValue.Contains(expectedValue, StringComparison.InvariantCultureIgnoreCase))
            {
                ReportManager.Instance.SetStepStatusPass($"{message}::[{actualValue}] contains [{expectedValue}]");
            }
            else
            {
                throw new AssertionException(
                        $"Test Failed due [{actualValue}] does not constains [{expectedValue}]");
            }
        }

        public static void CompareStringsEquals(string expectedValue, string actualValue, string message)
        {
            if (actualValue.Equals(expectedValue, StringComparison.InvariantCultureIgnoreCase))
            {
                ReportManager.Instance.SetStepStatusPass($"{message}::[{actualValue}] is equals to [{expectedValue}]");
            }
            else
            {
                throw new AssertionException(
                        $"Test Failed due [{actualValue}] is not equals to [{expectedValue}]");
            }
        }
    }
}
