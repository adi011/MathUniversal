using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MathUniversal.ViewModel
{
    class Matrix 
    {
        public int WidthSize
        {
            get;
            set;
        } 

        public int HeightSize
        {
            get;
            set;
        }

        public string CurrentPageKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Matrix(int width, int height)
        {
            WidthSize = width;
            HeightSize = height;
        }

      

      

       

        
    }
}
