using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace MathUniversal.ViewModel
{
    public class ExpressionsViewModel:ViewModelBase
    {
        public ExpressionsViewModel()
        {
            _expressions = new MathExpressions();
            _addCommand = new RelayCommand(AddExpressions);
        }


        private MathExpressions _expressions;
        public ObservableCollection<Expression> Expressions
        {
            get
            {
                return _expressions.Expressions;
            }

        }

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand;
            }
        }

        private void AddExpressions()
        {
            _expressions.Add();
        }
    }
}
