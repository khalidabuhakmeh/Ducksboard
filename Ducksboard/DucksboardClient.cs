using System;
using System.Collections.Generic;
using System.Linq;
using Ducksboard.Objects;
using Ducksboard.Serializers;
using RestSharp;

namespace Ducksboard
{
    public class DucksboardClient
    {
        private const string BaseUrl = "https://push.ducksboard.com/v/";
        private readonly string _apiKey;

        public DucksboardClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Used to update a widget. Use the correct object to set the value correctly. Consult the api documentation at http://dev.ducksboard.com/apidoc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="widget"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IRestResponse Update<T>(string widget, T data)
            where T : DucksboardObjectBase
        {
            if (data == null) throw new ArgumentNullException("data");

            return Execute(widget, data);
        }

        /// <summary>
        /// This method is used primarily with Numbers, some widgets allow you to pass
        /// multiple numbers in to update a widgets data. The Relative Graphs widget is an example.
        /// Consult the api documentation at http://dev.ducksboard.com/apidoc.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="widget"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IRestResponse Updates<T>(string widget, IEnumerable<T> data)
            where T: DucksboardObjectBase
        {
            if (widget == null) throw new ArgumentNullException("widget");
            if (data == null) throw new ArgumentNullException("data");

            return Execute(widget, data.ToArray());
        }

        private IRestResponse Execute(string widget, object data)
        {
            var client = new RestClient
            {
                BaseUrl = BaseUrl,
                Authenticator = new HttpBasicAuthenticator(_apiKey, "")
            };

            var request = new RestRequest(Method.POST)
            {
                JsonSerializer = new RestSharpDataContractJsonSerializer(),
                RequestFormat = DataFormat.Json,
                Resource = widget
            };

            request.AddBody(data);

            var response = client.Execute(request);
            return response;
        }
    }
}