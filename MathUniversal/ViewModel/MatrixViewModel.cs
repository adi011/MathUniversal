using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MathUniversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MathUniversal.ViewModel
{

    public class MatrixViewModel:ViewModelBase
    {

        public MatrixViewModel()
        {
             _panel = new MatrixPanel();
            _backToStartCommand = new RelayCommand(BackNavigation);
            //_introduceSize = new RelayCommand(DrawMatrix);
            //_toCount = new RelayCommand(CountMatrix);

            _addMatrixPanel = new RelayCommand(AddPanel);
        }



        private RelayCommand _addMatrixPanel;

        public RelayCommand AddMatrixPanel
        {
            get
            {
                return _addMatrixPanel;
            }
        }


        private MatrixPanel _panel;
        //public ObservableCollection<MatrixPanel> Panels
        //{

        //    get
        //    {
        //        return _panel;
        //    }
            


        //}








        void AddPanel()
        {
           // panel.Add();
        }















        private RelayCommand _backToStartCommand;
        public RelayCommand BackToStartCommand
        {
            get
            {
                return _backToStartCommand;
            }
        }

        
        void BackNavigation()
        {
            Navigation.NavigationToStartPage();
        }

        private RelayCommand _introduceSize;
        public RelayCommand IntroduceSize
        {
            get
            {
                return _introduceSize;
            }
        }

        void DrawMatrix()
        {
            //Calineczka1
        }

        private RelayCommand _toCount;
        public RelayCommand ToCount
        {
            get
            {
                return _toCount;
            }
        }

        void CountMatrix()
        {
            //Calineczka2
        }


    }

}
