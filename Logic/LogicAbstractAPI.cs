using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bilard.Data;

namespace Bilard.Logic
{
    public abstract class LogicAbstractAPI
    {
        public abstract void AddBall();

        public abstract void RemoveBall();

        public abstract List<Ball> GetBalls();

        public abstract void MoveBalls();

        public static LogicAbstractAPI CreateAPI()
        {
            return new LogicAPI();
        }
    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private List<Ball> balls;

        public int sizeX { get; set; } = 800;

        public int sizeY { get; set; } = 500;

        private Random random = new Random();

        private DataAbstractAPI dataAPI;

        public LogicAPI()
        {
            balls = new List<Ball>();
            dataAPI = DataAbstractAPI.CreateAPI();
        }

        public override void MoveBalls()
        {
            foreach (var ball in balls)
            {
                ball.X += ball.XSpeed;
                ball.Y += ball.YSpeed;
                if (ball.X < 0 || ball.X + ball.Diameter > sizeX)
                {
                    ball.XSpeed *= -1;
                }
                if (ball.Y < 0 || ball.Y + ball.Diameter > sizeY)
                {
                    ball.YSpeed *= -1;
                }

            }
        }

        public override void AddBall()
        {
            int randomSpeedx;
            int randomSpeedy;
            do { 
                randomSpeedx = random.Next(-5,5);
                randomSpeedy = random.Next(-5,5);
            } while (randomSpeedx ==  0 && randomSpeedy == 0);
            balls.Add(new Ball(random.Next(10, 770), random.Next(10, 470), 20, randomSpeedx, randomSpeedy));
        }

        public override void RemoveBall()
        {
            balls.RemoveAt(balls.Count - 1);
        }

        public override List<Ball> GetBalls()
        {
            return balls;
        }
    }
}
