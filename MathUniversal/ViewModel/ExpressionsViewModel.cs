using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using MathUniversal.Model;

namespace MathUniversal.ViewModel
{
    public class ExpressionsViewModel:ViewModelBase
    {
        public ExpressionsViewModel()
        {
            _expressions = new MathExpressions();
            AddCommand = new RelayCommand(() => _expressions.Add());
        }


        private MathExpressions _expressions;
        public ObservableCollection<Expression> Expressions => _expressions.Expressions;
        public RelayCommand AddCommand { get; }
        public RelayCommand GoBackCommand { get; } = new RelayCommand(()=>Navigation.GoBack());

    }
}
