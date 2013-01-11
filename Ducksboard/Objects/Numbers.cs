using System;
using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Numbers : DucksboardObjectBase
    {
        public Numbers(DateTime? timestamp = null)
        {
            if (timestamp.HasValue)
            {
                Timestamp = ConvertToUnixTimestamp(timestamp.Value);
            }
        }

        /// <summary>
        /// The value of the number.
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal? Value { get; set; }

        /// <summary>
        /// Delta values cannot appear in lists and their timestamps are ignored, they are always treated as differences from the current value.
        /// </summary>
        [DataMember(Name = "delta", EmitDefaultValue = false)]
        public decimal? Delta { get; set; }

        /// <summary>
        /// Timestamps should be UNIX timestamps in seconds, expressed as numbers with an optional fractional part. If no timestamp is specified, the value is assumed to be timestamped with the current time.
        /// </summary>
        [DataMember(Name = "timestamp", EmitDefaultValue = false)]
        public double? Timestamp { get; set; }

        /// <summary>
        /// A convenience property, will set the Timestamp property with the correct Unix timestamp. Will not be part of serialization.
        /// </summary>
        [IgnoreDataMember]
        public DateTime? Date
        {
            get { return Timestamp.HasValue ? ConvertFromUnixTimestamp(Timestamp.Value) : (DateTime?) null; }
            set { Timestamp = value.HasValue ? ConvertToUnixTimestamp(value.Value) : (double?) null; }
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}