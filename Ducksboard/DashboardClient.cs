using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using Ducksboard.Serializers;
using Ducksboard.TypeExtensions;
using RestSharp;

namespace Ducksboard
{
    public class DashboardClient
    {
        private const string BaseUrl = "https://app.ducksboard.com/api/";
        private readonly RestClient _client;

        /// <summary>
        /// Creates a new ducsboard client for using the dashboard API.
        /// </summary>
        /// <param name="apiKey"></param>
        public DashboardClient(string apiKey)
        {
            _client = new RestClient
                {
                    BaseUrl = BaseUrl,
                    Authenticator = new HttpBasicAuthenticator(apiKey, "")
                };

            _client.AddHandler("application/json", new RestSharpDataContractJsonDeserializer());
        }

        /// <summary>
        /// Gets collection of all resources of the given type from the dashboard api.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : new()
        {
            var response = _client.Execute<GetCollectionResponse<T>>(
                new RestRequest(
                    typeof (T).GetResourceFromTypeDataContractAttribute() + "/",
                    Method.GET)
                    {
                        RequestFormat = DataFormat.Json
                    });

            return response.Data.Data;
        }

        /// <summary>
        /// Creates a new resource
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newObject"></param>
        /// <returns></returns>
        public T Create<T>(T newObject) where T : new()
        {
            var request = new RestRequest(
                typeof (T).GetResourceFromTypeDataContractAttribute() + "/",
                Method.POST)
                {
                    JsonSerializer = new RestSharpDataContractJsonSerializer(),
                    RequestFormat = DataFormat.Json
                };

            request.AddBody(newObject);

            var response = _client.Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.OK) return response.Data;
            throw new Exception(response.StatusDescription, response.ErrorException);
        }

        /// <summary>
        /// Gets a specific resource by it's slug
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="slug"></param>
        /// <returns></returns>
        public T Get<T>(string slug) where T : new()
        {
            var response = _client.Execute<T>(
                new RestRequest(
                    typeof (T).GetResourceFromTypeDataContractAttribute() + "/" + slug,
                    Method.GET)
                    {
                        RequestFormat = DataFormat.Json
                    });

            if (response.StatusCode == HttpStatusCode.NotFound) return default(T);
            if (response.StatusCode == HttpStatusCode.OK) return response.Data;
            throw new Exception(response.StatusDescription, response.ErrorException);
        }

        /// <summary>
        /// Update existing resources. 
        /// If the payload is missing some fields, the resource being updated will 
        /// keep the values for them, for instance dashboard resources 
        /// have name and background fields.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToUpdate"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        public T Update<T>(T objectToUpdate, string slug) where T : new()
        {
            var request = new RestRequest(
               typeof(T).GetResourceFromTypeDataContractAttribute() + "/" + slug,
               Method.PUT)
            {
                JsonSerializer = new RestSharpDataContractJsonSerializer(),
                RequestFormat = DataFormat.Json
            };

            request.AddBody(objectToUpdate);

            var response = _client.Execute<T>(request);

            if (response.StatusCode == HttpStatusCode.OK) return response.Data;
            throw new Exception(response.StatusDescription, response.ErrorException);
        }

        /// <summary>
        /// Deletes an object by it's slug
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="slug"></param>
        /// <returns></returns>
        public bool Delete<T>(string slug)
        {
            var request = new RestRequest(
                typeof (T).GetResourceFromTypeDataContractAttribute() + "/" + slug,
                Method.DELETE);

            var response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK) return true;
            if (response.StatusCode == HttpStatusCode.NotFound) return false;
            throw new Exception(response.StatusDescription, response.ErrorException);
        }

        [DataContract]
        internal class GetCollectionResponse<T> where T : new()
        {
            [DataMember(Name = "count")]
            public string Count { get; set; }

            [DataMember(Name = "data")]
            public List<T> Data { get; set; }
        }
    }
}