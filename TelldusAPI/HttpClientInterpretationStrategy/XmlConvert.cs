using System.IO;
using System.Xml.Serialization;

namespace TelldusAPI
{
    public static class XmlConvert
    {
        public static T DeserializeObject<T>(string input)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(input))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}