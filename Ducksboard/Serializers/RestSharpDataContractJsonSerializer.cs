using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using RestSharp.Serializers;

namespace Ducksboard.Serializers
{
    public class RestSharpDataContractJsonSerializer : ISerializer
    {
        public RestSharpDataContractJsonSerializer()
        {
            ContentType = "application/json";
        }

        /// Serialize the object as JSON
        /// <param name="obj" />
        /// Object to serialize
        /// JSON as String
        public string Serialize(object obj)
        {
            //Create a stream to serialize the object to.
            using (var ms = new MemoryStream())
            {
                // Serializer the User object to the stream.
                var ser = new DataContractJsonSerializer(obj.GetType());
                ser.WriteObject(ms, obj);
                var json = ms.ToArray();
                return Encoding.UTF8.GetString(json, 0, json.Length);
            }
        }

        /// Unused for JSON Serialization
        public string DateFormat { get; set; }

        /// Unused for JSON Serialization
        public string RootElement { get; set; }

        /// Unused for JSON Serialization
        public string Namespace { get; set; }

        /// Content type for serialized content
        public string ContentType { get; set; }
    }
}