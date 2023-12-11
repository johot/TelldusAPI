using System.Collections.Generic;
using System.Xml.Serialization;

namespace TelldusAPI
{
    [XmlRoot(ElementName = "stateValues")]
    public class StateValues
    {
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
   
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "device")]
    public class Device
    {
        [XmlElement(ElementName = "stateValues")]
        public List<StateValues> StateValues { get; set; }
    
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    
        [XmlAttribute(AttributeName = "clientDeviceId")]
        public int ClientDeviceId { get; set; }
   
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
     
        [XmlAttribute(AttributeName = "state")]
        public string State { get; set; }
     
        [XmlAttribute(AttributeName = "statevalue")]
        public string Statevalue { get; set; }
     
        [XmlAttribute(AttributeName = "methods")]
        public int Methods { get; set; }
     
        [XmlAttribute(AttributeName = "metadataHash")]
        public string MetadataHash { get; set; }
     
        [XmlAttribute(AttributeName = "parametersHash")]
        public string ParametersHash { get; set; }
     
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
      
        [XmlAttribute(AttributeName = "client")]
        public int Client { get; set; }
     
        [XmlAttribute(AttributeName = "clientName")]
        public string ClientName { get; set; }
     
        [XmlAttribute(AttributeName = "online")]
        public int Online { get; set; }
     
        [XmlAttribute(AttributeName = "editable")]
        public bool Editable { get; set; }
       
        [XmlAttribute(AttributeName = "ignored")]
        public bool Ignored { get; set; }
    }

    [XmlRoot(ElementName = "devices")]
    public class DeviceContainer
    {
        [XmlElement(ElementName = "device")]
        public List<Device> Device { get; set; }
    }
}