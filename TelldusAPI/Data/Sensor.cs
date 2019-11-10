using System;
using System.Collections.Generic;
using System.Text;

namespace TelldusAPI
{
    public class Sensor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int LastUpdated { get; set; }
        public int Ignored { get; set; }
        public string Client { get; set; }
        public string ClientName { get; set; }
        public string Online { get; set; }
        public int Editable { get; set; }
        public int Battery { get; set; }
        public int KeepHistory { get; set; }
        public string Protocol { get; set; }
        public string Model { get; set; }
        public string SensorId { get; set; }
        public string MiscValues { get; set; }
        public string Temp { get; set; }
        public string Humidity { get; set; }
    }
}
