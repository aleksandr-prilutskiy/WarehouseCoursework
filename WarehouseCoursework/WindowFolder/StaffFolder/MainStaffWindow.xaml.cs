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
using System.Windows.Shapes;
using WarehouseCoursework.ClassFolder;
using WarehouseCoursework.DataFolder;
using WarehouseCoursework.PageFolder.StaffFolder;

namespace WarehouseCoursework.WindowFolder.StaffFolder
{
    /// <summary>
    /// Interaction logic for MainStaffWindow.xaml
    /// </summary>
    public partial class MainStaffWindow : Window
    {
        public MainStaffWindow()
        {
            InitializeComponent();
            UsernameLabel.Content = "LoginUser";
            //UsernameLabel.Content = $"{GV.Staff.SurnameStaff}" + $"{GV.Staff.NameStaff}";
            MainFrame.Navigate(new ProductListPage());
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var question = MB.Quiestion("Вы действительно хотите выйти из учетной записи?");

            if (question)
            {
                new AuthorizationWindow().Show();
                this.Close();
            }
        }

        private void PackIcon_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MB.Exit();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
