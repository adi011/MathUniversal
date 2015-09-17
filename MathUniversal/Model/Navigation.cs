using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MathUniversal.Model
{
    public static class Navigation
    {
        private static Frame rootFrame = Window.Current.Content as Frame;
        public static void NavigationToStartPage()
        {
            rootFrame.Navigate(typeof(StartPage));
        }

        public static void NavigationToExpressionsPage()
        {
            rootFrame.Navigate(typeof(ExpressionsPage));
        }
        public static void NavigationToMatrixPage()
        {
            rootFrame.Navigate(typeof(MatrixPage));
        }
        public static void NavigationToTheSystemOfEquationsPage()
        {
            rootFrame.Navigate(typeof(TheSystemOfEquationsPage));
        }


    }
}
