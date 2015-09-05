﻿using System;
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
        public MathExpressions()
        {
            var first = new Expression(OnExpressionChanged) { ExpressionString = "" };
            Expressions.Add(first);
        }

        private void OnExpressionChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ExpressionString")
            {
                ParseExpression((Expression)sender);
            }
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
        private void ParseExpression(Expression expression)
        {
            if (String.IsNullOrEmpty(expression.ExpressionString))
            {
                expression.Result = null;
                expression.ErrorMessage = null;
                return;
            }
            if (Parser.PrimaryContext.AllVariables.ContainsKey(expression.Name))
            {
                Parser.RemoveVariable(expression.Name);
            }
            try {
                expression.Result = Parser.Parse(expression.ExpressionString).Execute();
                var b = Parser.Parse(expression.ExpressionString);
                if (!String.IsNullOrEmpty(expression.Name))
                {
                    Parser.AddVariable(expression.Name, expression.Result);
                }
            }
            catch(Exception e)
            {
                expression.ErrorMessage = e.Message;
                expression.Result = null;
            }
        }

        public void Add()
        {
            var a = new Expression(OnExpressionChanged) {ExpressionString = "" };
            Expressions.Add(a);
        }
    }
}
