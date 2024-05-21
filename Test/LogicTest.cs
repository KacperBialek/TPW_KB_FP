using Bilard.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Bilard.Tests
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void CreateApiTest()
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI();
            Assert.IsNotNull(api);
        }
        [TestMethod]
        public void AddRemoveBallsTest() 
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI();
            Assert.AreEqual(api.GetBalls().Count, 0);
            api.AddBall();
            api.AddBall();
            api.AddBall();
            Assert.AreEqual(api.GetBalls().Count, 3);
            Thread.Sleep(1000);
            api.RemoveBall();
            Assert.AreEqual(api.GetBalls().Count, 2);
        }
        
    }
}
