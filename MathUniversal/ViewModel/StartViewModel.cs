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

        public RelayCommand NavigateToExpressions { get; } = new RelayCommand(() => Navigation.NavigateTo(typeof(ExpressionsPage)));
        public RelayCommand NavigateToMatrix { get; } = new RelayCommand(() => Navigation.NavigateTo(typeof(MatrixPage)));
        public RelayCommand NavigateToTheSystemOfEquations { get; } = new RelayCommand(() => Navigation.NavigateTo(typeof(TheSystemOfEquationsPage)));


    }
}
