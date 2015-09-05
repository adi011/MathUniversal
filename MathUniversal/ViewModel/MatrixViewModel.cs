using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MathUniversal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUniversal.ViewModel
{

    public class MatrixViewModel:ViewModelBase
    {

        public MatrixViewModel()
        {
            _backToStartCommand = new RelayCommand(BackNavigation);
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



    }

}
