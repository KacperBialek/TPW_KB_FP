using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bilard.Data;
using System.Numerics;

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
            Vector2 zero = new Vector2(0,0);
            Ball ball = new Ball(2.5f, 3.0f, 4, zero, 2, 1);
            Assert.AreEqual(2.5f, ball.Position.X);
            Assert.AreEqual(3.0f, ball.Position.Y);
            Assert.AreEqual(4, ball.Diameter);
            Assert.AreEqual(zero, ball.Speed);
            Assert.AreEqual(2, ball.Mass);
            Assert.AreEqual(1,ball.ID);
            Vector2 spd = new Vector2(0, 2);
            ball.Speed = spd;
            Assert.AreEqual(spd, ball.Speed);

        }
        [TestMethod]
        public void AddBallTest() 
        {
            DataAbstractAPI api = DataAbstractAPI.CreateAPI();
            Assert.IsNotNull(api);

            Ball ball = api.AddBall(0);
            Assert.IsNotNull(ball);
            int diam = ball.Diameter;
            int mass = ball.Mass;
            float x = ball.Position.X;
            float y = ball.Position.Y;

            Assert.AreEqual(diam * 2, ball.Mass);
            Assert.IsTrue(diam >= 30);
            Assert.IsTrue(diam <= 50);
            Assert.IsTrue(x >= -10);
            Assert.IsTrue(x <= 830);
            Assert.IsTrue(y >= -10);
            Assert.IsTrue(y <= 530);
            Assert.AreEqual(0, ball.ID);
        }
    }
}
