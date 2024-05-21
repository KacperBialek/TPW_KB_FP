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
        private float x;
        private float y;
        private int diameter;
        private string color;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float X
        {   
            get { return x; } 
            set { 
                x = value;
                RaisePropertyChanged();
            }
        }

        public float Y
        {
            get { return y; }
            set
            {
                y = value;
                RaisePropertyChanged();
            }
        }

        public int Diameter
        { 
            get { return diameter; } 
        }

        public string Color
        {
            get { return color; }
        }

        public ModelBall(float x, float y, int diameter, string color)
        {
            this.x = x;
            this.y = y;
            this.diameter = diameter;
            this.color = color;
        }
    }
}
