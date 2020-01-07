using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace TelldusAPI.Test
{
    [TestClass]
    public class DeviceTests : TelldusApiTestConfiguration
    {
        [TestMethod]
        public async Task GetAllDevicesTest()
        {
            var helper = new TelldusApiTestHelper();
            var telldusClient = helper.CreateTelldusClient();
            var data = await telldusClient.GetDevicesAsync();
            Assert.IsNotNull(data, "Should contain data");
        }

        [TestMethod]
        public async Task XmlResponseAndJsonResponseShouldBeTheSameTest()
        {
            var helper = new TelldusApiTestHelper();
            var telldusJsonClient = helper.CreateTelldusClient(ClientType.JSON);
            var jsonData = await telldusJsonClient.GetDevicesAsync();

            var telldusXmlClient = helper.CreateTelldusClient(ClientType.XML);
            var xmlData = await telldusXmlClient.GetDevicesAsync();
            Assert.IsTrue(OrderedIds(jsonData).SequenceEqual(OrderedIds(xmlData)), "Should be equal");
        }

        private IEnumerable<int> OrderedIds(IEnumerable<Device> data)
        {
            return data.Select(x => x.Id).OrderBy(id => id);
        }
    }
}