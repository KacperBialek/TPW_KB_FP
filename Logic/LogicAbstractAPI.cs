using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Bilard.Data;

namespace Bilard.Logic
{
    public abstract class LogicAbstractAPI
    {
        public abstract void AddBall();

        public abstract void RemoveBall();

        public abstract List<Ball> GetBalls();

        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract event EventHandler<(int Id, float X, float Y)>? LogicEvent;

        public static LogicAbstractAPI CreateAPI()
        {
            return new LogicAPI();
        }
    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private List<Ball> balls;

        private readonly object Lock = new();

        public override int Width { get; }
        public override int Height { get; }

        public override event EventHandler<(int Id, float X, float Y)>? LogicEvent;

        private ConcurrentDictionary<(int, int), bool> StateOfCollision = new ConcurrentDictionary<(int, int), bool>();

        private DataAbstractAPI dataAPI;

        public LogicAPI()
        {
            balls = new List<Ball>();
            dataAPI = DataAbstractAPI.CreateAPI();
            Width = dataAPI.Width;
            Height = dataAPI.Height;
        }

        public override void AddBall()
        {
            balls.Add(dataAPI.AddBall(balls.Count));
            GetBalls().Last().BallChanged += PositionChanged;
        }
       
        public override void RemoveBall() 
        {
            GetBalls().Last().BallChanged -= PositionChanged;
            GetBalls().Last().Dispose();
            balls.Remove(GetBalls().Last());
        }

        public override List<Ball> GetBalls()
        {
            return balls;
        }

        private void PositionChanged(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            Ball ball = (Ball)sender;
            lock (Lock)
            {
                BallCollision(ball);
            }
            WallCollision(ball);
            LogicEvent?.Invoke(this, (ball.ID, ball.X, ball.Y));
        }


        private void BallCollision(Ball firstBall)
        {
            foreach (Ball secondBall in balls) 
            {            
                if (firstBall == secondBall) //przerywamy jeżeli to ta sama kulka
                {
                    continue;
                }

                if (!CheckState(firstBall, secondBall) && IsBallCollision(firstBall, secondBall))
                {
                    AddState(firstBall, secondBall);

                    Vector2 newFirstBallSpeed = NewSpeed(firstBall, secondBall);
                    Vector2 newSecondBallSpeed = NewSpeed(secondBall, firstBall);
                    if (Vector2.Distance(firstBall.Position, secondBall.Position) > Vector2.Distance(firstBall.Position + newFirstBallSpeed, secondBall.Position + newSecondBallSpeed))
                    {
                        return;
                    }
                    firstBall.Speed = newFirstBallSpeed;
                    secondBall.Speed = newSecondBallSpeed;
                }
                else
                {
                    RemoveState(firstBall, secondBall);
                }
            }
        }

        private void AddState(Ball firstBall, Ball secondBall)
        {
            int id1 = firstBall.ID;
            int id2 = secondBall.ID;
            var key = (id1, id2);
            StateOfCollision.TryAdd(key, true);
        }

        private void RemoveState(Ball firstBall, Ball secondBall)
        {
            int id1 = firstBall.ID;
            int id2 = secondBall.ID;
            var key = (id1, id2);
            StateOfCollision.Remove(key, out _);
        }

        private bool CheckState(Ball firstBall, Ball secondBall)
        {
            int id1 = firstBall.ID;
            int id2 = secondBall.ID;
            var key = (id1, id2);
            return StateOfCollision.ContainsKey(key);
        }


        private Vector2 NewSpeed(Ball firstBall, Ball secondBall)
        {
            var firstBallSpeed = firstBall.Speed;
            var secondBallSpeed = secondBall.Speed;
            var distance = firstBall.Position - secondBall.Position;
            return firstBall.Speed - 2.0f * secondBall.Mass / (firstBall.Mass + secondBall.Mass) * (Vector2.Dot(firstBallSpeed - secondBallSpeed, distance) * distance) / (float)Math.Pow(distance.Length(), 2);
        }

        private bool IsBallCollision(Ball firstBall, Ball secondBall)
        {
            if (firstBall == null || secondBall == null)
            {
                return false;
            }
            float distance = Vector2.Distance(firstBall.Position, secondBall.Position);
            return distance <= (firstBall.Diameter + secondBall.Diameter) / 2;
        }

        private void WallCollision(Ball ball)
        {
            Vector2 newVel = new Vector2(ball.Speed.X, ball.Speed.Y);

            if (ball.X < 0 || ball.X + ball.Diameter > Width)
            {
                newVel.X *= -1;
            }
            if (ball.Y < 0 || ball.Y + ball.Diameter > Height)
            {
                newVel.Y *= -1;
            }

            ball.Speed = newVel;
        }
    }
}
