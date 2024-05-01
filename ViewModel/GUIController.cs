using Bilard.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bilard.ViewModel
{
    public class GUIController : ViewModelBase
    {
        public ICommand add { get; }
        public ICommand del { get; }

        private ModelAbstractAPI modelAPI;
        public ObservableCollection<ModelBall> ballsOnBoard { get; }

        private bool isAddEnable;
        private bool isDelEnable;


        public GUIController() {

            isAddEnable = true;
            isDelEnable = false;

            add = new RelayCommand(AddToBoard);
            del = new RelayCommand(DelFromBoard);

            modelAPI = ModelAbstractAPI.CreateApi();

            modelAPI.Start();

            ballsOnBoard = modelAPI.ModelBalls;
        }

        public void AddToBoard(){
            
            modelAPI.AddBall();
            modelAPI.AddModelBall();

            isDelEnable = true;

            OnPropertyChanged(nameof(IsDelEnable));
            OnPropertyChanged(nameof(ballsOnBoard));
        }

        public void DelFromBoard(){
            
            modelAPI.RemoveBall();
            modelAPI.RemoveModelBall();

            if (ballsOnBoard.Count == 0){
                isDelEnable = false;
                OnPropertyChanged(nameof(IsDelEnable));
            }

            OnPropertyChanged(nameof(ballsOnBoard));
        }

        public bool IsAddEnable
        {
            get => isAddEnable;
            set
            {
                isAddEnable = value;
                OnPropertyChanged(nameof(IsAddEnable));
            }

        }

        public bool IsDelEnable
        {
            get => isDelEnable;
            set
            {
                isDelEnable = value;
                OnPropertyChanged(nameof(IsDelEnable));
            }
        }
    }
}
