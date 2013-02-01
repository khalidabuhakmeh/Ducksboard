using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    [DataContract]
    public class Status : DucksboardObjectBase
    {
        public Status()
        {
            Value = StatusCode.OK;
        }

        [DataMember(Name = "value")]
        public StatusCode Value { get; set; }

        public enum StatusCode
        {
            OK = 0,
            ERROR = 1,
            WARNING = 2,
            UNKNOWN = 3
        }
    }
}