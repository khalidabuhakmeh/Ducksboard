using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Leaderboard : DucksboardObjectBase
    {
        public Leaderboard()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        public Leaderboard Add(string name, params decimal[] values)
        {
            var item = new Payload.BoardItem();
            item.Name = name;
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
            }
        }
    }
}