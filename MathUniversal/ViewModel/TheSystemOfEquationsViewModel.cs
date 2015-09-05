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
            backToStartCommand = new RelayCommand(BackNavigation);
        }

        private RelayCommand backToStartCommand;

        public RelayCommand BackToStartCommand
        {
            get
            {
                return backToStartCommand;
            }
        }



        private void BackNavigation()
        {
            Navigation.NavigationToStartPage();
        }
    }
}
