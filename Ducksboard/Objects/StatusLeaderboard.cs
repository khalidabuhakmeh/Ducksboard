using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class StatusLeaderboard : DucksboardObjectBase
    {
        public StatusLeaderboard()
        {
            Value = new Payload();
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        public StatusLeaderboard Add(string name, string status, params string[] values)
        {
            var item = new Payload.BoardItem
                           {
                               Name = name,
                               Status = status,
                           };

            if (values != null)
                foreach (string value in values)
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
                    Values = new List<string>();
                    Status = StatusLeaderboard.Status.Gray;
                }

                [DataMember(Name = "name")]
                public string Name { get; set; }

                [DataMember(Name = "values")]
                public IList<string> Values { get; set; }

                [DataMember(Name = "status")]
                public string Status { get; set; }
            }
        }

        public static class Status
        {
            public const string Green = "green";
            public const string Yellow = "yellow";
            public const string Red = "red";
            public const string Gray = "gray";
        }
    }
}