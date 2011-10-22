using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots;

namespace MarsTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class OrientationsTest
    {
        public OrientationsTest()
        {
            
        }

        [TestMethod]
        public void TestMovingLeftAndRight()
        {
            Assert.AreEqual<Orientation>(OrientationsHandler.ToLeft(OrientationsHandler.South), OrientationsHandler.East);
            Assert.AreEqual<Orientation>(OrientationsHandler.ToLeft(OrientationsHandler.East), OrientationsHandler.North);
            Assert.AreEqual<Orientation>(OrientationsHandler.ToLeft(OrientationsHandler.North), OrientationsHandler.West);
            Assert.AreEqual<Orientation>(OrientationsHandler.ToLeft(OrientationsHandler.West), OrientationsHandler.South);
            Assert.AreEqual<Orientation>(OrientationsHandler.ToLeft(OrientationsHandler.South), OrientationsHandler.East);

            Assert.AreEqual<Orientation>(OrientationsHandler.ToRight(OrientationsHandler.South), OrientationsHandler.West);
            Assert.AreEqual<Orientation>(OrientationsHandler.ToRight(OrientationsHandler.West), OrientationsHandler.North);
            Assert.AreEqual<Orientation>(OrientationsHandler.ToRight(OrientationsHandler.North), OrientationsHandler.East);
            Assert.AreEqual<Orientation>(OrientationsHandler.ToRight(OrientationsHandler.East), OrientationsHandler.South);
            //
            // TODO: Add test logic here
            //
        }
    }
}
