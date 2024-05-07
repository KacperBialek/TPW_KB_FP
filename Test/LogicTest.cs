using Bilard.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
            api.RemoveBall();
            Assert.AreEqual(api.GetBalls().Count, 2);
        }
        
        [TestMethod]
        public void MoveBallsTest() 
        {
            LogicAbstractAPI api = LogicAbstractAPI.CreateAPI();
            api.AddBall();
            Assert.AreEqual(api.GetBalls().Count, 1);
            double[] position = new double[4];
            position[0] = api.GetBalls()[0].X;
            position[1] = api.GetBalls()[0].Y;
            api.MoveBalls();
            position[2] = api.GetBalls()[0].X;
            position[3] = api.GetBalls()[0].Y;
            Assert.AreNotEqual(position[0] * position[1], position[2] * position[3]);
        }
    }
}
