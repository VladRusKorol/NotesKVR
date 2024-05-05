using System.Configuration;
using System.Data;
using System.Windows;
using Notes.APL.View.Windows.CheckAuthorizedAccount_View;

namespace Notes.APL
{
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var CheckAuthorizedAccount_View = new CheckAuthorizedAccount_View();
            CheckAuthorizedAccount_View.Show();
            CheckAuthorizedAccount_View.IsVisibleChanged += (s, ev) =>
            {
                try
                {
                    if (CheckAuthorizedAccount_View.IsVisible == false && CheckAuthorizedAccount_View.IsLoaded)
                    {
                        var mainView = new MainWindow();
                        mainView.Show();
                        CheckAuthorizedAccount_View.Close();
                    }
                }
                catch
                {
                    Application.Current.Shutdown();
                }

               
            };
        }
    }

}
