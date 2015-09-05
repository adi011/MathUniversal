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
                    return;
                ParserNameChange(value);
                RaisePropertyChanged("Name");
            }
        }

        private void ParserNameChange(string newName)
        {
            NameErrorMessage = null;
            if(Parser.PrimaryContext.AllVariables.ContainsKey(newName) && newName != _name)    // Variable name is already used by other expression
            {
                NameErrorMessage = "Error: Name already exixts";
                _name = null;
                return;
            }

            try
                {
                if (_name!=null && Parser.PrimaryContext.AllVariables.ContainsKey(_name))
                {
                    Parser.RemoveVariable(_name);
                }
                _name = newName;
                if (!String.IsNullOrEmpty(newName))
                    Parser.AddVariable(newName, Result);
            }
                catch
                {
                    NameErrorMessage = "Error: Can't change name";
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
        private string _nameErrorMessage;
        public string NameErrorMessage
        {
            get
            {
                return _nameErrorMessage;
            }
            set
            {
                _nameErrorMessage = value;
                RaisePropertyChanged("NameErrorMessage");
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