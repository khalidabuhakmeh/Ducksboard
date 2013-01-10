using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Timeline : DucksboardObjectBase
    {
        public Timeline()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        [DataContract]
        public class Payload
        {
            [DataMember(Name = "title", EmitDefaultValue = false)]
            public string Title { get; set; }

            [DataMember(Name = "image", EmitDefaultValue = false)]
            public string Image { get; set; }

            [DataMember(Name = "content", EmitDefaultValue = false)]
            public string Content { get; set; }

            [DataMember(Name = "link", EmitDefaultValue = false)]
            public string Link { get; set; }
        }
    }
}