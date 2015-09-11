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
                _matrixWidth = value;
                RaisePropertyChanged("MatrixWidth");
            }
        }








    }
}
