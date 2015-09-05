﻿using GalaSoft.MvvmLight;
using YAMP;

namespace MathUniversal
{
    public class Expression:ObservableObject
    {
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

                _name = value;
                RaisePropertyChanged("Expressions");
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
                RaisePropertyChanged("Expressions");
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