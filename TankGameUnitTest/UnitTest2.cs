using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TankGame;

namespace TankGameUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        private const String PLAYERS_FULL = "PLAYERS_FULL#";
        private const String ALREADY_ADDED = "ALREADY_ADDED#";
        private const String GAME_ALREADY_STARTED = "GAME_ALREADY_STARTED";
        
        Main main = new Main();

        [TestMethod]
        public void LoginReqTest()
        {
            Assert.AreEqual("JOIN#", main.joinserver());
        }

        [TestMethod]
        public void LoginReplyTest()
        {
            Assert.AreEqual(3, main.serverJoinReply(GAME_ALREADY_STARTED));
        }

        [TestMethod]
        public void AcceptanceTest()
        {
            Assert.AreEqual(1, main.acceptance("s:p1:1,1:0#"));
        }

    }
}
