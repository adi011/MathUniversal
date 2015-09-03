using GalaSoft.MvvmLight;

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
    }
}