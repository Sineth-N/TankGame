using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TankGame;

namespace TankGameUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        Main main = new Main();
        [TestMethod]
        public void LoginReqTest()
        {
            Assert.AreEqual("JOIN#", main.joinserver());
        }
        [TestMethod]
        public void LoginReplyTest()
        {
            Assert.AreEqual(1, main.serverJoinReply("PLAYERS_FULL#"));
        }
    }
}
