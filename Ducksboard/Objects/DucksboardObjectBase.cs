using System;
using Ducksboard.Serializers;

namespace Ducksboard.Objects
{
    [Serializable]
    public abstract class DucksboardObjectBase
    {
        protected static readonly RestSharpDataContractJsonSerializer Serializer =
            new RestSharpDataContractJsonSerializer();

        public virtual string ToJson()
        {
            return Serializer.Serialize(this);
        }
    }
}