﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using MahApps.Metro.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ed_roadtoriches
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DisplayMainMenu();
        }




        void DisplayMainMenu()
        {
            if (CheckForDB())
            {
                // Display Default Menu //
            }
            else
            {
                // Display Import Dialogue //
            }
        }

        bool CheckForDB()
        {
            var pathToLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"/Waldemar_L/ed-roadtoriches/";
            if (Directory.Exists(pathToLocal)) //Check if %localappdata%/Waldemar_L/ed-roadtoriches/ exists
            {
                if (File.Exists(pathToLocal + "db.sql")){
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Directory.CreateDirectory(pathToLocal);
                return false;
            }
        }

        public void ChangeUI<T>(T page) where T:UserControl
        {
            this.contentControl.Content = page; 
        }
  
    }
}
