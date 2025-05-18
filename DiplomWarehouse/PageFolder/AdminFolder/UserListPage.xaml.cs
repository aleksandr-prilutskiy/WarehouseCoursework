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
    /// Interaction logic for UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
            MainLB.ItemsSource = App.Context.User.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTB.Text))
            {
                MainLB.ItemsSource = App.Context.User.ToList();
            }
            else
            {
                try
                {
                    MainLB.ItemsSource =
                        App.Context.User.
                        Where(x => x.LoginUser.
                        StartsWith(SearchTB.Text)).ToList();
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void UserAddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserAddPage());
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            GV.User = MainLB.SelectedValue as User;
            NavigationService.Navigate(new UserEditPage());
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            var user = MainLB.SelectedValue as User;
            var question = MB.Quiestion($"Вы действительно хотите удалить пользователя {user.LoginUser}");

            if (question)
            {
                var staff = App.Context.Staff.FirstOrDefault(x => x.IdUser == user.IdUser);

                if (staff != null)
                {
                    MB.Error("К данному юзеру привязан сотрдуник, для удаления юзера, вам треубется удалить сотрдуника!");
                    return;
                }
                try
                    {
                        App.Context.User.Remove(user);
                        App.Context.SaveChanges();
                        MB.Info($"Вы успешно удалили пользователя {user.LoginUser}");
                        NavigationService.Navigate(new UserListPage());
                    }
                    catch (Exception ex)
                    {
                        MB.Error(ex);
                    }
            }
        }
    }
}
