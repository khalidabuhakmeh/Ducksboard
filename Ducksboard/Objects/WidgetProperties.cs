using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ducksboard.Objects
{

    [DataContract]
    public class WidgetProperties : DucksboardObjectBase
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "dashboard")]
        public string Dashboard { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "row")]
        public int Row { get; set; }

        [DataMember(Name = "column")]
        public int Column { get; set; }

        [DataMember(Name = "sound")]
        public bool Sound { get; set; }
    }
}
