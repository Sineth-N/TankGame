using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TankGame;
namespace TankGameUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Main main=new Main();
            Assert.AreEqual(1, main.testMethod(1));
        }

    }
}
