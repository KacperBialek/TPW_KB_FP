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
        float X { get; }
        float Y { get; }
        int Diameter { get; }

        string Color { get; }
    }

    public abstract class ModelAbstractAPI
    {
        public ObservableCollection<ModelBall> ModelBalls { get; set; }

        public abstract void AddModelBall();

        public abstract void AddBall();

        public abstract void RemoveModelBall();

        public abstract void RemoveBall();

        public static ModelAbstractAPI CreateApi()
        {
            return new ModelAPI();
        }
    }

    internal class ModelAPI : ModelAbstractAPI
    {
        private LogicAbstractAPI logicAPI;

        private Random random = new Random();

        public ModelAPI()
        {
            ModelBalls = new ObservableCollection<ModelBall>();
            logicAPI = LogicAbstractAPI.CreateAPI();
            logicAPI.LogicEvent += Move;
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
            int id_ball = logicAPI.GetBalls().Count;
            ModelBalls.Add(new ModelBall(logicAPI.GetBalls()[id_ball - 1].X, logicAPI.GetBalls()[id_ball - 1].Y, logicAPI.GetBalls()[id_ball - 1].Diameter, color));
        }

        public override void RemoveModelBall()
        {
            ModelBalls.RemoveAt(ModelBalls.Count - 1);
        }

        private void Move(object? sender, (int Id, float X, float Y) args)
        {
            ModelBalls[args.Id].X = logicAPI.GetBalls()[args.Id].X;
            ModelBalls[args.Id].Y = logicAPI.GetBalls()[args.Id].Y;
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
