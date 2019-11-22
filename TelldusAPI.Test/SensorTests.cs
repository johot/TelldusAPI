using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelldusAPI.Test
{
    [TestClass]
    public class SensorTests : TelldusApiTestConfiguration
    {
        [TestMethod]
        public async Task GetAllSensorsTest()
        {
            var helper = new TelldusApiTestHelper();
            var telldusClient = helper.CreateTelldusClient();
            var data = await telldusClient.GetSensorsAsync();
            Assert.IsNotNull(data, "Should contain data");
        }

        [TestMethod]
        public async Task XmlResponseAndJsonResponseShouldBeTheSameTest()
        {
            var helper = new TelldusApiTestHelper();
            var telldusJsonClient = helper.CreateTelldusClient(ClientType.JSON);
            var jsonData = await telldusJsonClient.GetSensorsAsync();

            var telldusXmlClient = helper.CreateTelldusClient(ClientType.XML);
            var xmlData = await telldusXmlClient.GetSensorsAsync();
            Assert.IsTrue(OrderedIds(jsonData).SequenceEqual(OrderedIds(xmlData)), "Should be equal");
        }

        private IEnumerable<int> OrderedIds(IEnumerable<Sensor> data)
        {
            return data.Select(x => x.Id).OrderBy(id => id);
        }
    }
}