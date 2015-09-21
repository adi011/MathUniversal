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

             _panel = new MergeMatrix();
            _backToStartCommand = new RelayCommand(BackNavigation);
            _addPanelCommand = new RelayCommand(AddPanel);
        }

        private MergeMatrix _panel;

        public ObservableCollection<MatrixPanel> Panels
        {
            get
            {
                return _panel.Panels;
            }
        }

        private RelayCommand _addPanelCommand;
        public RelayCommand AddPanelCommand
        {
            get
            {
                return _addPanelCommand;
            }
            
        }

        private void AddPanel()
        {

            _panel.Add();
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
            Navigation.GoBack();
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
