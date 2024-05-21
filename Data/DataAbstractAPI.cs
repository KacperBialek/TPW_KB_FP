using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bilard.Data
{
    public abstract class DataAbstractAPI
    {
        public abstract Ball AddBall(int balls_amout);
        
        public abstract int Width { get; }
        public abstract int Height { get; }

        public static DataAbstractAPI CreateAPI()
        {
            return new DataAPI();
        }
    }

    internal class DataAPI : DataAbstractAPI
    {
        public DataAPI()
        {

        }

        public override int Width { get; } = 800;
        public override int Height { get; } = 500;

        private readonly Random random = new Random();

        public override Ball AddBall(int balls_amount)
        {
            float speedx;
            float speedy;
            do { 
                speedx = random.Next(-1,1);
                speedy = random.Next(-1,1);
            } while (speedx ==  0 && speedy == 0);
            Vector2 sped = new Vector2(speedx, speedy);
            int diam = random.Next(30,50);
            return new Ball(random.Next(10, 770), random.Next(10, 470), diam, sped, diam * 2, balls_amount);
        }
    }
}
