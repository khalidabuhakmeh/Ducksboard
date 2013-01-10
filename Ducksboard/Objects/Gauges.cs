using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Gauges : DucksboardObjectBase
    {
        [DataMember(Name = "value")]
        public decimal Value { get; set; }
    }
}