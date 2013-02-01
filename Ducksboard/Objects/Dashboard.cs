using System.Runtime.Serialization;

namespace Ducksboard.Objects
{

    [DataContract(Name = "dashboards")]
    public class Dashboard : DucksboardObjectBase
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "background")]
        public string Background { get; set; }

        [DataMember(Name = "layout")]
        public int? Layout { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

    }
}
