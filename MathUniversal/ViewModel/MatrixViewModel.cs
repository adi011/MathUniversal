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
            backToStart = new RelayCommand(BackNavigation);
        }



        public RelayCommand BackToStart
        {
            get
            {
                return backToStart;
            }
        }

        private RelayCommand backToStart;


        void BackNavigation()
        {
            Navigation.NavigationToStartPage();
        }



    }

}
