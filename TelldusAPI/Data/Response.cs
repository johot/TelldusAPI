using System.Xml.Serialization;

namespace TelldusAPI
{
    [XmlRoot(ElementName = "device")]
    public class Response
    {
        [XmlElement(ElementName = "error", IsNullable = true)]
        public string Error { get; set; }

        [XmlElement(ElementName = "status", IsNullable = true)]
        public string Status { get; set; }
    }
}