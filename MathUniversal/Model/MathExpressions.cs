using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using YAMP;

namespace MathUniversal
{
    public class MathExpressions:ObservableObject
    {
        public MathExpressions()
        {
            var first = new Expression() { Name = "X", ExpressionString = "" };
            Expressions.Add(first);
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
        public void Calculate()
        {
            foreach(var expression in Expressions)
            {
                try {
                    expression.Result = Parser.Parse(expression.ExpressionString).Execute();
                }
                catch(Exception e)
                {

                }
            }
        }
    }
}
