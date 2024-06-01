using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes.APL.Common
{
    public static class WindowsOpenController
    {
        public static bool ICanOpenThisWindow(string windowName)
        {
            var result =  (int)Application.Current.Resources[windowName] == 0 ? true : false;
            return result;
        }

        public static void ChangeCountOpenThisWindow(string windowName)
        {
            Application.Current.Resources[windowName] = (int)Application.Current.Resources[windowName] + 1; 
        }

        public static void ChangeCountCloseThisWindow(string windowName)
        {
            Application.Current.Resources[windowName] = (int)Application.Current.Resources[windowName] - 1; 
        }
    }
}
