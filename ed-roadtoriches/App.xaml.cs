using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ed_roadtoriches
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        MainWindow window;
        void App_Startup(object sender, StartupEventArgs e)
        {
            window = new MainWindow();
            window.Show();
        }
        public void PassReference(MainWindow v)
        {
            window = v;
        }

        public MainWindow GetMainWindow()
        {
            return window;
        }
        public void ChangeUI<T>(T page) 
        {
            window.contentControl.Content = page;
        }
    }
}
