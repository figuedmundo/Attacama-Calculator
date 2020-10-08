using System;
using System.Collections.Generic;
using RestSharp;
using Captiva.Reports;

namespace Captiva.Api.Manager
{
    public class RestSharpManager
    {
        public RestSharpManager(string baseUrl)
        {
            Client = new RestClient(baseUrl);
            ReportManager.Instance.SetStepStatusPass("RestShrap started.");
        }

        public RestClient Client { get; private set; }


        public T GetRequest<T>(string endpoint)
        {

            var request = new RestRequest(endpoint, DataFormat.Json);
            return (T)Client.Get<T>(request);
        }

        public IRestResponse GetRequest(string path, List<Parameter> parameters)
        {

            var request = new RestRequest(path, Method.GET);
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }

            return Client.Get(request);
        }

        public IRestResponse PostRequest(string path, List<Parameter> parameters)
        {

            var request = new RestRequest(path, Method.POST);
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }

            return Client.Post(request);
        }
    }
}