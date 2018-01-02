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

using Newtonsoft.Json;

namespace ed_roadtoriches.pages
{
    /// <summary>
    /// Interaktionslogik für DB_parsefromFile.xaml
    /// </summary>
    public partial class DB_parsefromFile : UserControl
    {
        public DB_parsefromFile()
        {
            InitializeComponent();
            ((App)Application.Current).PassReference(this);
        }

        public void ParsefromFile(String file)
        {
            database.DBConnect dBConnect = new database.DBConnect();
        }

    }
}
