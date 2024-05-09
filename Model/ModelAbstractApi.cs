using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using Bilard.Logic;

namespace Bilard.Model
{
    public interface IBall : INotifyPropertyChanged
    {
        double X { get; }
        double Y { get; }
        double Diameter { get; }

        string Color { get; }
    }

    public abstract class ModelAbstractAPI
    {
        public ObservableCollection<ModelBall> ModelBalls { get; set; }

        public abstract void AddModelBall();

        public abstract void AddBall();

        public abstract void RemoveModelBall();

        public abstract void RemoveBall();

        public abstract void Start();

        public static ModelAbstractAPI CreateApi()
        {
            return new ModelAPI();
        }
    }

    internal class ModelAPI : ModelAbstractAPI
    {
        private LogicAbstractAPI logicAPI;

        private Timer timer;

        private Random random = new Random();

        public ModelAPI()
        {
            ModelBalls = new ObservableCollection<ModelBall>();
            logicAPI = LogicAbstractAPI.CreateAPI();
        }

        public override void AddModelBall()
        {
            int int_color = random.Next(1, 6);
            string color = "";
            if (int_color == 1) {
                color = "blue";
            } else if (int_color == 2){
                color = "yellow";
            } else if (int_color == 3){
                color = "red";
            } else if (int_color == 4){
                color = "orange";
            }else if (int_color == 5){
                color = "white";
            }
            ModelBalls.Add(new ModelBall(logicAPI.GetBalls()[0].X, logicAPI.GetBalls()[0].Y, logicAPI.GetBalls()[0].Diameter, color));
        }

        public override void RemoveModelBall()
        {
            ModelBalls.RemoveAt(ModelBalls.Count - 1);
        }

        public override void Start()
        {
            timer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(10));
        }

        public void Move(object? state)
        {
            logicAPI.MoveBalls();
            for(int i = 0; i < ModelBalls.Count; i++)
            {
                ModelBalls[i].X = logicAPI.GetBalls()[i].X;
                ModelBalls[i].Y = logicAPI.GetBalls()[i].Y;
            }
        }

        public override void AddBall()
        {
            logicAPI.AddBall();
        }

        public override void RemoveBall()
        {
            logicAPI.RemoveBall();
        }
    }
}    
