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
using WarehouseCoursework.ClassFolder;
using WarehouseCoursework.DataFolder;

namespace WarehouseCoursework.PageFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for StaffListPage.xaml
    /// </summary>
    public partial class StaffListPage : Page
    {
        public StaffListPage()
        {
            InitializeComponent();
            MainLB.ItemsSource = App.Context.Staff.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTB.Text))
            {
                MainLB.ItemsSource = App.Context
                    .Staff.ToList();
            }
            else
            {
                try
                {
                    MainLB.ItemsSource = App.Context
                        .Staff.Where(x => x.SurnameStaff
                        .StartsWith(SearchTB.Text) ||
                        x.MailStaff.StartsWith(SearchTB.Text) ||
                        x.PhoneStaff.StartsWith(SearchTB.Text) ||
                        x.User.LoginUser.StartsWith(SearchTB.Text)).ToList();
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void StaffAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffAddPage());
        }

        private void InfoMI_Click(object sender, RoutedEventArgs e)
        {
            GV.Staff = MainLB.SelectedValue as Staff;
            NavigationService.Navigate(new StaffInfoPage());
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            GV.Staff = MainLB.SelectedValue as Staff;
            NavigationService.Navigate(new StaffEditPage());
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            var staff = MainLB.SelectedValue as Staff;
            var question = MB.Quiestion($"Вы действительно хотите удалить сотрдуника {staff.SurnameStaff} {staff.NameStaff}?");

            if (question)
            {
                try
                {
                    DeleteStaff();
                    MB.Info($"Сотрдуник {staff.SurnameStaff} {staff.NameStaff} успешно удален!");
                    NavigationService.Navigate(new StaffListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void DeleteStaff()
        {
            var staff = MainLB.SelectedValue as Staff;
            var user = App.Context.User.FirstOrDefault(x => x.IdUser == staff.User.IdUser);

            App.Context.User.Remove(user);
            App.Context.Staff.Remove(staff);

            App.Context.SaveChanges();
        }
    }
}
