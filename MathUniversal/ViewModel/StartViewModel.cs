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
            _navigateToExpressions = new RelayCommand(NavigationExpression);
            _navigateToMatrix = new RelayCommand(NavigationMatrix);
            _navigateToTheSystemOfEquations = new RelayCommand(NavigationSystemOfEquations);
        }

        private RelayCommand _navigateToExpressions;
        public RelayCommand NavigateToExpressions
        {
            get
            {
                return _navigateToExpressions;
            }
        }



        private RelayCommand _navigateToMatrix;
        public RelayCommand NavigateToMatrix
        {
            get
            {
                return _navigateToMatrix;
            }
        }
        private RelayCommand _navigateToTheSystemOfEquations;
        public RelayCommand NavigateToTheSystemOfEquations
        {
            get
            {
                return _navigateToTheSystemOfEquations;
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
