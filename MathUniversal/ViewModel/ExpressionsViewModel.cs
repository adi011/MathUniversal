using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace MathUniversal.ViewModel
{
    public class ExpressionsViewModel:ViewModelBase
    {

        private MathUniversalExpressions _expressions;
        public MathUniversalExpressions Expressions
        {
            get
            {
                return _expressions;
            }

            set
            {
                if (_expressions == value)
                {
                    return;
                }

                _expressions = value;
                RaisePropertyChanged("Expressions");
            }
        }
    }
}
