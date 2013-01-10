using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Numbers : DucksboardObjectBase
    {
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal? Value { get; set; }

        [DataMember(Name = "delta", EmitDefaultValue = false)]
        public decimal? Delta { get; set; }
    }
}