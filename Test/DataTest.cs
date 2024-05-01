using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bilard.Data;

namespace Bilard.Tests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void CreateAPITest()
        {
            DataAbstractAPI api = DataAbstractAPI.CreateAPI();
            Assert.IsNotNull(api);
        }
        [TestMethod]
        public void BallTest()
        {
            Ball ball = new Ball(2.5, 3.0, 4.3, 1.5, 2.0);
            Assert.AreEqual(2.5, ball.X);
            Assert.AreEqual(3.0, ball.Y);
            Assert.AreEqual(4.3, ball.Diameter);
            Assert.AreEqual(1.5, ball.XSpeed);
            Assert.AreEqual(2.0, ball.YSpeed);
        }
    }
}
