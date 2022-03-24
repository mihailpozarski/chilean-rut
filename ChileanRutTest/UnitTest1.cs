using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChileanRutify;

namespace ChileanRutTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidValues()
        {
            
            string value = "";

            Assert.IsFalse(ChileanRut.ValidRutValue(value));
            value = "0";
            Assert.IsTrue(ChileanRut.ValidRutValue(value));
            value = "1";
            Assert.IsTrue(ChileanRut.ValidRutValue(value));
            value = "2";
            Assert.IsTrue(ChileanRut.ValidRutValue(value));
            value = "K";
            Assert.IsTrue(ChileanRut.ValidRutValue(value));
            value = "k";
            Assert.IsTrue(ChileanRut.ValidRutValue(value));
            value = "y";
            Assert.IsFalse(ChileanRut.ValidRutValue(value));
            value = "/";
            Assert.IsFalse(ChileanRut.ValidRutValue(value));
        }
    }
}
