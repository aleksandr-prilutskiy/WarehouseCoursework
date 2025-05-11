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

namespace WarehouseCoursework.PageFolder.AdminFolder
{
    /// <summary>
    /// Interaction logic for UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        public UserEditPage()
        {
            InitializeComponent();
            DataContext = GV.User;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ChangePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserChangePassword());
        }

        private void UserEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MB.Error("Введите логин!");
                LoginTB.Focus();
                return;
            }
            else if (LoginTB.Text.Length < 3)
            {
                MB.Error("Логин не может быть меньше 3х символов!");
                LoginTB.Focus();
                return;
            }
            else
            {
                try
                {
                    EditUser();
                    MB.Info("Изминения сохранены!");
                    NavigationService.Navigate(new UserListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }
        private void EditUser()
        {
            var user = App.Context.User.FirstOrDefault(x => x.IdUser == GV.User.IdUser);

            user.LoginUser = LoginTB.Text;

            App.Context.SaveChanges();
        }
    }
}
