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
        pages.DB_parsefromFile dB_ParsefromFile;
        void App_Startup(object sender, StartupEventArgs e)
        {
            window = new MainWindow();
            window.Show();
        }
        public void PassReference(MainWindow v)
        {
            window = v;
        }
        public void PassReference(pages.DB_parsefromFile v)
        {
            dB_ParsefromFile = v;
        }

        public MainWindow GetMainWindow()
        {
            return window;
        }
        public pages.DB_parsefromFile GetDB_ParsefromFile()
        {
            return dB_ParsefromFile;
        }



        public void ChangeUI<T>(T page) 
        {
            window.contentControl.Content = page;
        }
    }
}
