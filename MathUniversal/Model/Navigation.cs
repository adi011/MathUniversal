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
        public static void NavigationToStartPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(StartPage));
        }

        public static void NavigationToExpressionsPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ExpressionsPage));
        }
        public static void NavigationToMatrixPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MatrixPage));
        }
        public static void NavigationToTheSystemOfEquationsPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TheSystemOfEquationsPage));
        }


    }
}
