using Ducksboard.Serializers;

namespace Ducksboard.Tests.Objects
{
    public class SerializationTest
    {
        protected SerializationTest()
        {
            Serializer = new RestSharpDataContractJsonSerializer();
        }

        protected RestSharpDataContractJsonSerializer Serializer { get; set; }
    }
}