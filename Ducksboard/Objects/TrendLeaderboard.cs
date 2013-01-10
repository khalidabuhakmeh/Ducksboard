using System.Collections.Generic;

namespace Ducksboard.Objects
{
    public class TrendLeaderboard : DucksboardObjectBase
    {
        public TrendLeaderboard()
        {
            Value = new Payload();
        }

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

        public class Payload
        {
            public Payload()
            {
                Board = new List<BoardItem>();
            }

            public IList<BoardItem> Board { get; set; }

            public class BoardItem
            {
                public BoardItem()
                {
                    Values = new List<decimal>();
                }

                public string Name { get; set; }
                public IList<decimal> Values { get; set; }
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