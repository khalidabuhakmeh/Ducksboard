using System.Runtime.Serialization;

namespace Ducksboard.Objects
{
    /// <summary>
    /// The image widget will accept both image urls and base64 encoded images.
    /// </summary>
    [DataContract]
    public class Image : DucksboardObjectBase
    {
        public Image()
            : this(string.Empty)
        {
        }

        public Image(string source, string caption = "")
        {
            Value = new Payload {Source = source, Caption = caption};
        }

        [DataMember(Name = "value")]
        public Payload Value { get; set; }

        [DataContract]
        public class Payload
        {
            [DataMember(Name = "source", EmitDefaultValue = false)]
            public string Source { get; set; }

            [DataMember(Name = "caption", EmitDefaultValue = false)]
            public string Caption { get; set; }
        }
    }
}