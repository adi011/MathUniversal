using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using MathUniversal;
using Windows.UI.Xaml;
using MathUniversal.Model;

namespace MathUniversal.ViewModel
{

    public class TheSystemOfEquationsViewModel:ViewModelBase
    {

        public TheSystemOfEquationsViewModel()
        {
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
            Navigation.NavigationToStartPage();
        }
    }
}
