using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bilard.Model
{
    public class ModelBall : IBall
    {
        private double x;
        private double y;
        private double diameter;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double X
        {   
            get { return x; } 
            set { 
                x = value;
                RaisePropertyChanged();
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                RaisePropertyChanged();
            }
        }

        public double Diameter
        { 
            get { return diameter; } 
        }
        
        public ModelBall(double x, double y, double diameter)
        {
            this.x = x;
            this.y = y;
            this.diameter = diameter;
        }
    }
}
