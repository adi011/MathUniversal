using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using YAMP;

namespace MathUniversal
{
    public class Expression:ObservableObject
    {
        public Expression(PropertyChangedEventHandler OnExpressionChanged)
        {
            PropertyChanged += OnExpressionChanged;
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    return;
                }
                ParserNameChange(value);
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private void ParserNameChange(string newName)
        {
            if (Result != null && !String.IsNullOrEmpty(_name))
            {
                try
                {
                    Parser.RemoveVariable(_name);
                    Parser.AddVariable(newName, Result);
                }
                catch
                {
                    ErrorMessage = "Error: Can't change name";
                }
            }
        }

        private string _expressionString;

        public string ExpressionString
        {
            get
            {
                return _expressionString;
            }

            set
            {
                if (_expressionString == value)
                {
                    return;
                }

                _expressionString = value;
                RaisePropertyChanged("ExpressionString");
            }
        }
        private Value _result;
        public Value Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (_result == value)
                {
                    return;
                }

                _result = value;
                RaisePropertyChanged("Result");
                RaisePropertyChanged("ResultString");
            }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if (_errorMessage == value)
                {
                    return;
                }

                _errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
                RaisePropertyChanged("ResultString");
            }
        }
        public string ResultString
        {
            get
            {
                if (Result != null)
                {
                    return Result.ToString();
                }else
                {
                    return ErrorMessage;
                }
            }
        }
    }
}