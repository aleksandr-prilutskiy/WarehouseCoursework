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
    /// Interaction logic for UserAddPage.xaml
    /// </summary>
    public partial class UserAddPage : Page
    {
        public UserAddPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UserAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MB.Error("Введите логин!");
                LoginTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MB.Error("Введите пароль!");
                PasswordPB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PasswordRepeatPB.Password))
            {
                MB.Error("Введите пароль повторно!");
                PasswordRepeatPB.Focus();
                return;
            }
            else if (PasswordPB.Password != PasswordRepeatPB.Password)
            {
                MB.Error("Пароль не совпадает!");
                PasswordRepeatPB.Focus();
                return;
            }
            else
            {
                try
                {
                    AddUser();
                    MB.Info($"Пользователь {LoginTB.Text}, успешно добавлен");
                    NavigationService.Navigate(new UserListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void AddUser()
        {
            var user = new User()
            {
                LoginUser = LoginTB.Text,
                PasswordUser = PasswordPB.Password,
                IdRole = 1
            };

            App.Context.User.Add(user);
            App.Context.SaveChanges();
        }
    }
}
