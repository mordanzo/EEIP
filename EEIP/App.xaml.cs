using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EEIP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string dbName = "EEIP.db";
        static string folderPath = Environment.CurrentDirectory;
        public static string dbPath = System.IO.Path.Combine(folderPath, dbName);
    }
}
