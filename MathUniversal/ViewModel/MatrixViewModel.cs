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
            backToStartCommand = new RelayCommand(BackNavigation);
        }



        public RelayCommand BackToStartCommand
        {
            get
            {
                return backToStartCommand;
            }
        }

        private RelayCommand backToStartCommand;


        void BackNavigation()
        {
            Navigation.NavigationToStartPage();
        }



    }

}
