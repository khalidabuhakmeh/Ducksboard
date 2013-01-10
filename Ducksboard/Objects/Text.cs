using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Text : DucksboardObjectBase
    {
        public Text()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        [DataContract]
        public class Payload
        {
            [DataMember(Name = "content")]
            public string Content { get; set; }
        }
    }
}