using System.Collections.Generic;
using System.Xml.Serialization;

namespace TelldusAPI
{
    [XmlRoot(ElementName = "sensor")]
    public class Sensor
    {
        [XmlAttribute(AttributeName = "battery")]
        public int Battery { get; set; }
  
        [XmlAttribute(AttributeName = "client")]
        public int Client { get; set; }
  
        [XmlAttribute(AttributeName = "clientName")]
        public string ClientName { get; set; }
   
        [XmlAttribute(AttributeName = "editable")]
        public bool Editable { get; set; }
    
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
  
        [XmlAttribute(AttributeName = "ignored")]
        public bool Ignored { get; set; }
    
        [XmlAttribute(AttributeName = "keepHistory")]
        public bool KeepHistory { get; set; }
     
        [XmlAttribute(AttributeName = "lastUpdated")]
        public long LastUpdated { get; set; }
     
        [XmlAttribute(AttributeName = "miscValues")]
        public string MiscValues { get; set; }
     
        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }
  
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
   
        [XmlAttribute(AttributeName = "online")]
        public int Online { get; set; }
     
        [XmlAttribute(AttributeName = "protocol")]
        public string Protocol { get; set; }
     
        [XmlAttribute(AttributeName = "sensorId")]
        public int SensorId { get; set; }
     
        [XmlAttribute(AttributeName = "temp")]
        public decimal Temp { get; set; }
     
        [XmlAttribute(AttributeName = "unknown")]
        public string Unknown { get; set; }
     
        [XmlAttribute(AttributeName = "watt")]
        public decimal Watt { get; set; }
    
        [XmlAttribute(AttributeName = "wavg")]
        public decimal Wavg { get; set; }

        [XmlAttribute(AttributeName = "humidity")]
        public int Humidity { get; set; }
    }

    [XmlRoot(ElementName = "sensors")]
    public class Sensors
    {
        [XmlElement(ElementName = "sensor")]
        public List<Sensor> Sensor { get; set; }
    }
}