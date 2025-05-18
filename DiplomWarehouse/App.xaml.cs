using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WarehouseCoursework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DataFolder.DB Context { get; } = new DataFolder.DB();
        public static DataFolder.DB CurrentUser = null;
    }
}
