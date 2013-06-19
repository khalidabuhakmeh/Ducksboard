using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class TrendLeaderboard : DucksboardObjectBase
    {
        public TrendLeaderboard()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        public TrendLeaderboard Add(string name, string trend, params decimal[] values)
        {
            var item = new Payload.BoardItem
            {
                Name = name,
                Trend = trend,
            };

            if (values != null)
                foreach (decimal value in values)
                    item.Values.Add(value);

            Value.Board.Add(item);

            return this;
        }

        [DataContract]
        public class Payload
        {
            public Payload()
            {
                Board = new List<BoardItem>();
            }

            [DataMember(Name = "board")]
            public IList<BoardItem> Board { get; set; }

            [DataContract]
            public class BoardItem
            {
                public BoardItem()
                {
                    Values = new List<decimal>();
                }

                [DataMember(Name = "name")]
                public string Name { get; set; }

                [DataMember(Name = "values")]
                public IList<decimal> Values { get; set; }

                [DataMember(Name = "trend", EmitDefaultValue = false)]
                public string Trend { get; set; }
            }
        }

        public static class Trends
        {
            public const string Up = "up";
            public const string Down = "down";
            public const string Equal = "Equal";
        }
    }
}