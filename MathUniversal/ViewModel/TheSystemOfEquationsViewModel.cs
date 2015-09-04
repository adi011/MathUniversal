using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MathUniversal.ViewModel
{

    public class TheSystemOfEquationsViewModel:ViewModelBase
    {

        public TheSystemOfEquationsViewModel()
        {
            something = new Matrice(2,2);
            systemOfEquations = new RelayCommand(BackNavigation);
        }

        private RelayCommand systemOfEquations;

        public RelayCommand SystemOfEquations
        {
            get
            {
                return systemOfEquations;
            }
        }



        private void BackNavigation()
        {
            something.BackToStart();
        }


        private Matrice something;


    }
}
