using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MathUniversal.Model
{
    public static class Navigation
    {
        private static Frame rootFrame = Window.Current.Content as Frame;
        private static Stack<Type> lastPages = new Stack<Type>();
        public static void NavigateTo(Type pageType)
        {
            if (rootFrame != null)
            { 
            lastPages.Push(rootFrame.CurrentSourcePageType);
            rootFrame.Navigate(pageType);
            }
        }
        public static void GoBack()
        {
            if (rootFrame != null && lastPages.Count>0)
            {
                rootFrame.Navigate(lastPages.Pop());
            }
        }

        public static void BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            if (lastPages.Count > 0)
            {
                GoBack();
            }
            else
            {
                Application.Current.Exit();
            }
        }
    }
}
