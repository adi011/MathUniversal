using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace MathUniversal
{
    public class MathUniversalExpressions:ObservableObject
    {
        private ObservableCollection<Expression> _expressions=new ObservableCollection<Expression>();
        public ObservableCollection<Expression> Expressions
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
