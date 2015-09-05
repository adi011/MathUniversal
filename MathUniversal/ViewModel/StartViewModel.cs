using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUniversal.ViewModel
{
    public class StartViewModel:ViewModelBase
    {

        public StartViewModel()
        {
           // navigateToExpressions = new RelayCommand(Calineczka1);
            //navigateToMatrix = new RelayCommand(Calineczka2);
            //navigateToTheSystemOfEquations = new RelayCommand(Calineczka3)
        }

        private RelayCommand navigateToExpressions;
        public RelayCommand NavigateToExpressions
        {
            get
            {
                return navigateToExpressions;
            }
        }



        private RelayCommand navigateToMatrix;
        public RelayCommand NavigateToMatrix
        {
            get
            {
                return navigateToMatrix;
            }
        }
        private RelayCommand navigateToTheSystemOfEquations;
        public RelayCommand NavigateToTheSystemOfEquations
        {
            get
            {
                return navigateToTheSystemOfEquations;
            }
        }





    }
}
