using System.Xml.Serialization;

namespace TelldusAPI.Data
{
    [XmlRoot(ElementName = "error")]
    public class ErrorResponse
    {
        [XmlAttribute(AttributeName = "error")]
        public string Error { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public int Code { get; set; }
        [XmlAttribute(AttributeName = "subcode")]
        public string Subcode { get; set; }
    }
}
