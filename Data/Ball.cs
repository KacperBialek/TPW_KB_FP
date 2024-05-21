using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bilard.Data
{
    public class Ball : IDisposable
    {
        private Task task;
        
        private int diameter { get; set; } = 10;
        private int mass { get; }

        private int id { get; }

        private Vector2 speed;

        private Vector2 position;

        private Stopwatch stopwatch;

        public event EventHandler? BallChanged;

        public Ball(float x, float y, int diameter, Vector2 speed, int mass, int id)
        {
            this.position = new Vector2(x, y);
            this.speed = speed;
            this.diameter = diameter;  
            this.mass = mass;
            this.id = id;
            stopwatch = new Stopwatch();
            task = Task.Run(Move);
        }

        public int Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }

        public int Mass
        {
            get { return mass; }
        }
        
        public int ID
        {
            get { return id; }
        }

        public Vector2 Speed
        {
            get => speed;
            set { speed = value; }
        }

        public Vector2 Position
        {
            get => position;

            private set { position = value; }
        }

        public float X => position.X;

        public float Y => position.Y;

        private async void Move()
        {
            int delay = 7;

            while (true) //Ta pętla zapewnia że czas wykonania jednej iteracji będzie wynosił dokładnie 15 milisekund
            {
                stopwatch.Restart();
                stopwatch.Start();

                Update(delay);

                stopwatch.Stop(); // Stopwatch mierzy czas wykonania metody Update
                await Task.Delay(delay - (int)stopwatch.ElapsedMilliseconds < 0 ? 0 : delay - (int)stopwatch.ElapsedMilliseconds); // Await wstrzymuje dany wątek a nie całą aplikację 
            }

        }

        private void Update(long time)
        {
            Position += speed * time;
            BallChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            task.Dispose();
        }
    }
}
