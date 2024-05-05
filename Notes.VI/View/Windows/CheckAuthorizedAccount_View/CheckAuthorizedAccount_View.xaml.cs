using Notes.APL.Common;
using Notes.BL;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Notes.APL.View.Windows.RegistrationWindow;

namespace Notes.APL.View.Windows.CheckAuthorizedAccount_View
{
    public partial class CheckAuthorizedAccount_View : Window
    {

        
        public CheckAuthorizedAccount_View()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_Wrap_CheckAuthorizedAccount_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Close_CheckAuthorizedAccount_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var regWindow = new Notes.APL.View.Windows.RegistrationWindow.RegistrationWindow(); 
            regWindow.Owner = this;
            regWindow.ShowDialog();

        }
    }

}
