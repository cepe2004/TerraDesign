using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TerraDesign.Forms.Waterfacil;

namespace TerraDesignTests
{
    [TestClass]
    public class TerraDesignTests
    {
        [TestMethod]
        public void speedCharacteristics_0_34_23_2returned()
        {
            //arrange
            double r = 0.34;
            double expected= 23.2;
            WFcheck wFcheck = new WFcheck();
            wFcheck.n = 0.020;
            //act
            double actual= wFcheck.speedCharacteristics(r);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
