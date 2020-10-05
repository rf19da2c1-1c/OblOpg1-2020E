using System;
using CykelLib.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CykelLibTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Dette er en rå test metode
            // God praksis er at lægge hver test ud i hver sin metode
            //

            Cykel c = new Cykel(1, "gul", 3400.50, 12);
            Assert.ThrowsException<ArgumentException>(() => c.Farve = "");
            c.Farve = "Y";
            Assert.AreEqual("Y", c.Farve);

            Assert.ThrowsException<ArgumentException>(() => c.Pris = 0);
            c.Pris = 0.01;
            Assert.AreEqual(0.01, c.Pris, 0.0001);

            Assert.ThrowsException<ArgumentException>(() => c.Gear = 2);
            c.Gear = 3;
            Assert.AreEqual(3, c.Gear);
            c.Gear = 32;
            Assert.AreEqual(32, c.Gear);
            Assert.ThrowsException<ArgumentException>(() => c.Gear = 33);
            



        }
    }
}
