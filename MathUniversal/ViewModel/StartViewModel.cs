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
    public class StartViewModel:ViewModelBase
    {

        public StartViewModel()
        {
             navigateToExpressions = new RelayCommand(NavigationExpression);
            navigateToMatrix = new RelayCommand(NavigationSystemOfEquations);
            navigateToTheSystemOfEquations = new RelayCommand(NavigationMatrix);
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

        void NavigationExpression()
        {
            Navigation.NavigationToExpressionsPage();
        }

        void NavigationSystemOfEquations()
        {
            Navigation.NavigationToTheSystemOfEquationsPage();
        }

        void NavigationMatrix()
        {
            Navigation.NavigationToMatrixPage();
        }



    }
}
