using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Funnel : DucksboardObjectBase
    {
        public Funnel()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        public Funnel Add(string name, int value)
        {
            Value.Funnel.Add(new Payload.FunnelItem(name, value));
            return this;
        }

        [DataContract]
        public class Payload
        {
            public Payload()
            {
                Funnel = new List<FunnelItem>();
            }

            [DataMember(Name = "funnel")]
            public IList<FunnelItem> Funnel { get; set; }

            [DataContract]
            public class FunnelItem
            {
                public FunnelItem(string name = "", int value = 0)
                {
                    Name = name;
                    Value = value;
                }

                [DataMember(Name = "name")]
                public string Name { get; set; }

                [DataMember(Name = "value")]
                public int Value { get; set; }
            }
        }
    }
}