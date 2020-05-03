using IMPLC.Core;
using IMPLC.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IMPLC.Test
{
    [TestClass]
    public class PLCServiceClientTest
    {
        [TestMethod]
        public void IPCConnect()
        {
            var client = PLCServiceProvider.GetServiceClient(PLCServiceType.IPC);

            IPLCServiceObject serviceObject = client.Connect("ipc://localhost:9090");
            var writeValue = new short[] { 1 };
            var readValue = new short[1];

            serviceObject.BlockWrite(eDevice.W, 0, (short)writeValue.Length, ref writeValue);

            serviceObject.BlockRead(eDevice.W, 0, (short)readValue.Length, ref readValue);

            Assert.AreEqual(1, readValue[0]);

        }
    }
}
