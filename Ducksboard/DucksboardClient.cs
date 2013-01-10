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

        public IRestResponse Update<T>(string widget, T data) where T : new()
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