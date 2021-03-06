﻿using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tests.Environment;
using Tests.Extensions;
using Tests.Helpers;

namespace Tests.Services
{
    public abstract class BaseService
    {
        protected virtual string Endpoint { get; }
        protected string Url => string.Concat(App.Configuration.Environment.BaseUrl, Endpoint);
        protected static StringContentFactory StringContentFactory { get; private set; } = new StringContentFactory(Encoding.UTF8, "application/json");

        private static HttpClient _client;

        protected HttpClient GetClient()
        {
            if (_client != null)
                return _client;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            return _client;
        }

        protected async Task<T> Post<T>(object requestBody)
        {
            var response = await Post(requestBody);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Server '{response.StatusCode}' status code");

            T value;
            try
            {
                value = response.GetContentAs<T>();
            }
            catch (Exception)
            {
                throw new Exception("Server return wrong data");
            }
            return value;
        }

        protected async Task<HttpResponseMessage> Post(object requestBody)
        {
            var content = UnboxRequestContentFromObjectToHttpContent(requestBody);
            var response = await GetClient().PostAsync(Url, content);
            return response;
        }

        private HttpContent UnboxRequestContentFromObjectToHttpContent(object requestBody)
        {
            switch (requestBody)
            {
                case string stringContent:
                    return StringContentFactory.CreateStringContent(stringContent);
                case HttpContent httpContent:
                    return httpContent;
                default:
                    return StringContentFactory.CreateStringContent(JsonConvert.SerializeObject(requestBody));
            }
        }
    }
}
