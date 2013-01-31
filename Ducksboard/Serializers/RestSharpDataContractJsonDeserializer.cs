using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Ducksboard.Serializers
{
    public class RestSharpDataContractJsonDeserializer : IDeserializer
    {

        /// Unused for JSON Serialization
        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            using (var ms = new MemoryStream(response.RawBytes))
            {
                var ser = new DataContractJsonSerializer(typeof (T));
                return (T) ser.ReadObject(ms);
            }
        }

        /// Unused for JSON Serialization
        public string RootElement { get; set; }

        /// Unused for JSON Serialization
        public string Namespace { get; set; }

    }
}