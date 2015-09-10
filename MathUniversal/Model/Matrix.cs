using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MathUniversal.ViewModel
{
    class Matrix: ObservableObject
    {
       



        public Matrix()
        {

        }





        private List<int> _values;
        List<int> Values
        {
            get
            {
                return _values;
            }
            set
            {

            }
        }

      

       

        
    }
}
