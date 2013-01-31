using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Slot : DucksboardObjectBase
    {
        [DataMember(Name = "1", EmitDefaultValue = false)]
        public SlotData Slot1 { get; set; }

        [DataMember(Name = "2", EmitDefaultValue = false)]
        public SlotData Slot2 { get; set; }

        [DataMember(Name = "3", EmitDefaultValue = false)]
        public SlotData Slot3 { get; set; }

        [DataMember(Name = "4", EmitDefaultValue = false)]
        public SlotData Slot4 { get; set; }

    }

    [DataContract]
    public class SlotData : DucksboardObjectBase
    {
        [DataMember(Name = "subtitle")]
        public string Subtitle { get; set; }

        [DataMember(Name = "timespan", EmitDefaultValue = false)]
        public string Timespan { get; set; }

        [DataMember(Name = "color", EmitDefaultValue = false)]
        public string Color { get; set; }

        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

    }
}
