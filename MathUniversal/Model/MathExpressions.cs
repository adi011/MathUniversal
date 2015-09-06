using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using YAMP;
using System.ComponentModel;

namespace MathUniversal
{
    public class MathExpressions:ObservableObject
    {
        private static MathExpressions _instance;
        public static MathExpressions Instance
        {
            get
            {
                return _instance;
            }
        }
        public MathExpressions()
        {
            var first = new Expression() { ExpressionString = "" };
            Expressions.Add(first);
            _instance = this;
        }


        private ObservableCollection<Expression> _expressions=new ObservableCollection<Expression>();

        public ObservableCollection<Expression> Expressions
        {
            get
            {
                return _expressions;
            }

            private set
            {
                if (_expressions == value)
                {
                    return;
                }

                _expressions = value;
                RaisePropertyChanged("Expressions");
            }
        }


        public void Add()
        {
            var a = new Expression() {ExpressionString = "" };
            Expressions.Add(a);
        }
    }
}
