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
    /// Interaction logic for StaffAddPage.xaml
    /// </summary>
    public partial class StaffAddPage : Page
    {
        public StaffAddPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            string cifri = "1234567890";
            if (string.IsNullOrWhiteSpace(SurnameTB.Text))
            {
                MB.Error("Введите фамилию!");
                SurnameTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(SurnameTB.Text.ToCharArray()) != -1)
            {
                MB.Error("Фамилия не может содержать цифры!");
                SurnameTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(NameTB.Text))
            {
                MB.Error("Введите имя!");
                NameTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(NameTB.Text.ToCharArray()) != -1)
            {
                MB.Error("Имя не может содержать цифры!");
                NameTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(MiddeNameTB.Text.ToCharArray()) != -1)
            {
                MB.Error("Отчество не может содержать цифры!");
                MiddeNameTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(DateOfBirthDP.Text))
            {
                MB.Error("Введите дату рождения!");
                DateOfBirthDP.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PhoneTB.Text))
            {
                MB.Error("Введите телефон!");
                PhoneTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(PhoneTB.Text.ToCharArray()) == -1)
            {
                MB.Error("Номер телефона должен содержать только цифры!");
                PhoneTB.Focus();
                return;
            }
            else if (PhoneTB.Text.Length != 11)
            {
                MB.Error("Номер телефона должна состоять из 11 цифр!" +
                    "\nПример: 79001234545");
                PhoneTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(MailTB.Text))
            {
                MB.Error("Введите почту!");
                MailTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(SeriesPassportTB.Text))
            {
                MB.Error("Введите серию паспорта!");
                SeriesPassportTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(SeriesPassportTB.Text.ToCharArray()) == -1)
            {
                MB.Error("Серия паспорта должена содержать только цифры!");
                SeriesPassportTB.Focus();
                return;
            }
            else if (SeriesPassportTB.Text.Length != 4)
            {
                MB.Error("Серия паспорта должна состоять из 4 цифр!");
                SeriesPassportTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(NumberPassportTB.Text))
            {
                MB.Error("Введите номер паспорта!");
                NumberPassportTB.Focus();
                return;
            }
            else if (cifri.IndexOfAny(NumberPassportTB.Text.ToCharArray()) == -1)
            {
                MB.Error("Номер паспорта должена содержать только цифры!");
                NumberPassportTB.Focus();
                return;
            }
            else if (NumberPassportTB.Text.Length != 6)
            {
                MB.Error("Номер паспорта должна состоять из 6 цифр!");
                NumberPassportTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MB.Error("Введите логин!");
                LoginTB.Focus();
                return;
            }
            else if (LoginTB.Text.Length < 3)
            {
                MB.Error("Логин должен состоять минимум их 3х символов!");
                LoginTB.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MB.Error("Введите пароль!");
                PasswordPB.Focus();
                return;
            }
            else if (PasswordPB.Password.Length < 3)
            {
                MB.Error("Пароль должен состоять минимум их 3х символов!");
                PasswordPB.Focus();
                return;
            }
            else
            {
                try
                {
                    AddStaff();
                    MB.Info($"Сотрдуник {SurnameTB.Text} {NameTB.Text} успешно добавлен!");
                    NavigationService.Navigate(new StaffListPage());
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
                IdRole = 2
            };
            App.Context.User.Add(user);
            App.Context.SaveChanges();
        }

        private void AddStaff()
        {
            AddUser();
            string middleCheck;
            if (string.IsNullOrEmpty(MiddeNameTB.Text))
            {
                middleCheck = "Отсутствует";
            }
            else
            {
                middleCheck = MiddeNameTB.Text;
            }
            var user = App.Context.User.FirstOrDefault(x => x.LoginUser == LoginTB.Text);
            var staff = new Staff()
            {
                SurnameStaff = SurnameTB.Text,
                NameStaff = NameTB.Text,
                MiddleNameStaff = middleCheck,
                DateOfBirthStaff = DateTime.Parse(DateOfBirthDP.Text.ToString()),
                PhoneStaff = PhoneTB.Text,
                MailStaff = MailTB.Text,
                SeriesPassportStaff = SeriesPassportTB.Text,
                NumberPassportStaff = NumberPassportTB.Text,
                IdUser = user.IdUser,
            };
            App.Context.Staff.Add(staff);
            App.Context.SaveChanges();
        }
    }
}
