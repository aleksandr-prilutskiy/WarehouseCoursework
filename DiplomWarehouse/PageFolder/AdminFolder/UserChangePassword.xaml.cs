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
    /// Interaction logic for UserChangePassword.xaml
    /// </summary>
    public partial class UserChangePassword : Page
    {
        public UserChangePassword()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewPasswordPB.Password))
            {
                MB.Error("Введите пароль!");
                NewPasswordPB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(RepeatNewPasswordPB.Password))
            {
                MB.Error("Введите пароль повторно!");
                RepeatNewPasswordPB.Focus();
                return;
            }
            else if (NewPasswordPB.Password.Length < 3)
            {
                MB.Error("Пароль должно состоять минимум из 3х символов!");
                NewPasswordPB.Focus();
                return;
            }
            else if (RepeatNewPasswordPB.Password != NewPasswordPB.Password)
            {
                MB.Error("Пароли не совпадают!");
                RepeatNewPasswordPB.Focus();
                return;
            }
            else
            {
                try
                {
                    ChangePassword();
                    MB.Info("Пароль для пользователя успешно изминен!");
                    NavigationService.Navigate(new UserListPage());
                }
                catch (Exception ex)
                {
                    MB.Error(ex);
                }
            }
        }

        private void ChangePassword()
        {
            var user = App.Context.User.FirstOrDefault(x => x.IdUser == GV.User.IdUser);

            user.PasswordUser = NewPasswordPB.Password;

            App.Context.SaveChanges();
        }
    }
}
