using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUniversal.Model
{
    public class MatrixPanel:ObservableObject
    {
        public MatrixPanel()
        {
            
             
        }
        private string _matrixHeight;
        public string MatrixHeight
        {
            get
            {
                return _matrixHeight;
            }
            set
            {
                if (CheckCorrectValue(value))
                    _matrixHeight = value;
                RaisePropertyChanged("MatrixHeight");
            }
        }
        private string _matrixWidth;
        public string MatrixWidth
        {
            get
            {
                return _matrixWidth;
            }
            set
            {
                if(CheckCorrectValue(value))
                    _matrixWidth = value;
                RaisePropertyChanged("MatrixWidth");
            }
        }


        private bool CheckCorrectValue(string value)
        {
            try
            {
                int content=Int32.Parse(value);
                if (content < 1) return false;
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }





    }
}
