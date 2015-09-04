using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MathUniversal.ViewModel
{
    class Matrice : INavigationService
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

        public Matrice(int width, int height)
        {
            WidthSize = width;
            HeightSize = height;
        }

        public void BackToStart()
        {
            GoBack();
            

        }

        public void GoBack()
        {
            
        }

        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
