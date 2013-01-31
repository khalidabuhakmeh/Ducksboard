using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Ducksboard.Objects
{
    [DataContract(Name = "widgets")]
    public class Widget: DucksboardObjectBase
    {
        [DataMember(Name = "widget")]
        public WidgetProperties WidgetProperties { get; set; }

        [DataMember(Name = "slots")]
        public Slot Slots { get; set; }

        public string Slug
        {
            get { return WidgetProperties != null ? WidgetProperties.Id.ToString() : string.Empty; }
        }
    }
}
