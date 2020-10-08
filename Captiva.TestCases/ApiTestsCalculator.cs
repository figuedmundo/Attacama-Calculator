using System;
using System.Net;
using Captiva.Api.Enpoint;
using Captiva.Api.Parameters;
using Captiva.TestCases.Base;
using NUnit.Framework;

namespace Captiva.TestCases
{
    public class ApiTestsCalculator : BaseTest
    {
        public ApiTestsCalculator() : base (true){
        }

        [Test]
        public void TestApiAddition()
        {
            var parameters = new CalculatorParameters()
            {
                Operation = "add",
                Value1 = "1",
                Value2 = "1"
            };

            var response = CalculatorEndpoints.GetOperation(parameters);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
