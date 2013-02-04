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
        [DataMember(Name = "timespan", EmitDefaultValue = false)]
        public string Timespan { get; set; }

        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        [DataMember(Name = "subtitle")]
        public string Subtitle { get; set; }

        [DataMember(Name = "subtitle1")]
        public string Subtitle1 { get; set; }

        [DataMember(Name = "subtitle2")]
        public string Subtitle2 { get; set; }

        [DataMember(Name = "subtitle3")]
        public string Subtitle3 { get; set; }
        
        [DataMember(Name = "subtitle4")]
        public string Subtitle4 { get; set; }
        
        [DataMember(Name = "subtitle5")]
        public string Subtitle5 { get; set; }
        
        [DataMember(Name = "subtitle6")]
        public string Subtitle6 { get; set; }
        
        [DataMember(Name = "subtitle7")]
        public string Subtitle7 { get; set; }
        
        [DataMember(Name = "subtitle8")]
        public string Subtitle8 { get; set; }

        [DataMember(Name = "subtitle9")]
        public string Subtitle9 { get; set; }

        [DataMember(Name = "color", EmitDefaultValue = false)]
        public string Color { get; set; }

        [DataMember(Name = "color1", EmitDefaultValue = false)]
        public string Color1 { get; set; }

        [DataMember(Name = "color2", EmitDefaultValue = false)]
        public string Color2 { get; set; }

        [DataMember(Name = "color3", EmitDefaultValue = false)]
        public string Color3 { get; set; }
        
        [DataMember(Name = "color4", EmitDefaultValue = false)]
        public string Color4 { get; set; }
        
        [DataMember(Name = "color5", EmitDefaultValue = false)]
        public string Color5 { get; set; }
        
        [DataMember(Name = "color6", EmitDefaultValue = false)]
        public string Color6 { get; set; }
        
        [DataMember(Name = "color7", EmitDefaultValue = false)]
        public string Color7 { get; set; }
        
        [DataMember(Name = "color8", EmitDefaultValue = false)]
        public string Color8 { get; set; }
        
        [DataMember(Name = "color9", EmitDefaultValue = false)]
        public string Color9 { get; set; }


    }
}
