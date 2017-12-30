using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed_roadtoriches
{
    class MainWindowViewModel
    {
        public int SwitchView // Window Index
        {
            get;set;
        }

        public MainWindowViewModel()
        {
            SwitchView = 0;
        }
        public MainWindowViewModel(int i)
        {
            SwitchView = i;
        }
        /*
         * 
         * 0 → DEFAULT MAIN MENU
         * 200 → NO DB FOUND
         * 201 → CREATE DB FROM FILE
         * 202 → CREATE DB FROM DOWNLOAD
         * 
         */

    }
}
