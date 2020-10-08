using System;
using System.Collections.Generic;
using Captiva.Api.Manager;
using Captiva.Api.Parameters;
using Captiva.Reports;
using Captiva.Utils.ConfigurationManager;
using RestSharp;

namespace Captiva.Api.Enpoint
{
    public class CalculatorEndpoints
    {
        public static readonly string API = Settings.Api;

        public static IRestResponse GetOperation(CalculatorParameters parameters)
        {
            var calcParams = new List<Parameter>()
            {
                new Parameter("val1", parameters.Value1, ParameterType.QueryString),
                new Parameter("val2", parameters.Value2, ParameterType.QueryString)
            };

            IRestResponse response = new RestSharpManager(API)
                .GetRequest(parameters.Operation, calcParams);

            ReportManager.Instance.SetStepStatusPass($"Get Request: [{parameters.Operation}], response: [{response}]");

            return response;
        }
    }
}
