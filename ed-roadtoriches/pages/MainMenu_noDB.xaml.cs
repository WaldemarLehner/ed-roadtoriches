using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace ed_roadtoriches.pages
{
    /// <summary>
    /// Interaktionslogik für MainMenu_noDB.xaml
    /// </summary>
    public partial class MainMenu_noDB : UserControl
    {
        public MainMenu_noDB()
        {
            InitializeComponent();
        }

        private void Downloaddataset(object sender, MouseButtonEventArgs e)
        {
            
        }

   

        private void ParsefromFile(object sender, MouseButtonEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "EDSM JSON dump (*.json)|*.json"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                ((App)Application.Current).ChangeUI(new pages.DB_parsefromFile());
                ((App)Application.Current).GetDB_ParsefromFile().testlabel.Content = openFileDialog.FileName;
                ((App)Application.Current).GetDB_ParsefromFile().ParsefromFile(openFileDialog.FileName);
            }
            
            
        }
    }
}
