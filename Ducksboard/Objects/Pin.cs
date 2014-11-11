using System.Runtime.Serialization;

namespace Ducksboard.Objects
{

    /// <summary>
    /// This will be submitted to the ducksboard API project.
    /// </summary>
    [DataContract]
    public class Pin : DucksboardObjectBase        
    {
        public Pin()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        [DataContract]
        public class Payload
        {
            [DataMember(Name = "latitude", EmitDefaultValue = false)]
            public decimal Latitude { get; set; }

            [DataMember(Name = "longitude", EmitDefaultValue = false)]
            public decimal Longitude { get; set; }

            [DataMember(Name = "ip", EmitDefaultValue = false)]
            public string IP { get; set; }

            [DataMember(Name = "value", EmitDefaultValue = false)]
            public decimal Value { get; set; }

            [DataMember(Name = "size", EmitDefaultValue = false)]
            public int Size { get; set; }

            [DataMember(Name = "info", EmitDefaultValue = false)]
            public string Info { get; set; }

            [DataMember(Name = "color", EmitDefaultValue = false)]
            public string Color { get; set; }
        }
    }
}