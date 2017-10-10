using System.Collections.Generic;

namespace TelldusAPI
{
    public class Device
    {
        public string Id { get; set; }
        public string ClientDeviceId { get; set; }
        public string Name { get; set; }
        public int state { get; set; }
        public string StateValue { get; set; }
        public int Methods { get; set; }
        public string Type { get; set; }
        public string Client { get; set; }
        public string ClientName { get; set; }
        public string Online { get; set; }
        public int Editable { get; set; }
        public int Ignored { get; set; }
        public string Devices { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

    public class Devices
    {
        public List<Device> Device { get; set; }
    }
}
