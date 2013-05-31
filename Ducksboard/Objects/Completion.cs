using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Completion : DucksboardObjectBase
    {
        public Completion()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        [DataContract]
        public class Payload
        {
            [DataMember(Name = "current", EmitDefaultValue = false)]
            public decimal? Current { get; set; }

            [DataMember(Name = "min", EmitDefaultValue = false)]
            public decimal? Min { get; set; }

            [DataMember(Name = "max", EmitDefaultValue = false)]
            public decimal? Max { get; set; }
        }
    }
}
