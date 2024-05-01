using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilard.Data
{
    public class Ball
    {

        private double x { get; set; }
        private double y { get; set; }
        private double diameter { get; set; } = 10;
        private double xSpeed { get; set; }
        private double ySpeed { get; set; }

        public Ball(double x, double y, double diameter, double xS, double yS)
        {
            this.x = x;
            this.y = y;
            this.diameter = diameter;  
            this.XSpeed = xS;
            this.YSpeed = yS;
        }

        public double X
        {
            get { return x; }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
            }
        }

        public double Diameter
        {
            get
            {
                return diameter;
            }
            set
            {
                diameter = value;
            }
        }

        public double XSpeed
        {
            get
            {
                return xSpeed;
            }
            set
            {
                xSpeed = value;
            }
        }

        public double YSpeed
        {
            get
            {
                return ySpeed;
            }
            set
            {
                ySpeed = value;
            }
        }

    }
}
