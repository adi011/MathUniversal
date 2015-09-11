using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUniversal.Model
{
    class MatrixPanel:ObservableObject
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
        }
        private string _matrixWidth;
        public string MatrixWidth
        {
            get
            {
                return _matrixWidth;
            }
        }








    }
}
