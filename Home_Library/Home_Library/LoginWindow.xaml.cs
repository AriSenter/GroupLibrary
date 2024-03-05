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

namespace Home_Library
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Capcha.Text = abc = CapchaGen.RandomString(4);
        }
        int i = 0;
        int j = 0;
        private string abc = string.Empty;
        public static class CapchaGen
        {
            public const string ValidLitters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwyz1234567890";
            private static readonly Random random = new Random();
            public static string RandomString(int length)
            {
                return string.Concat(Enumerable.Range(0, length).Select(_ => ValidLitters[random.Next(ValidLitters.Length)]));
            }
        }
        private void AuthorizationClick(object sender, RoutedEventArgs e)
        {
            if (Cap.Visibility == Visibility.Visible)
            {
                if (Cap.Text != Capcha.Text)
                {
                    MessageBox.Show("Капча не совпадает");
                    Capcha.Text = abc = CapchaGen.RandomString(4);
                    return;
                }
            }

            if (login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Пустые поля");
                return;
            }
          List<BIBKA_User> users = Helper.context.BIBKA_User.ToList();
            foreach (var us in users)
            {
                if (us.login == login.Text && us.password == password.Password)
                {
                    i = 0;
                    if (us.fk_id_role == 1)
                    {
                        MessageBox.Show("Вы авторизованы");
                        LibrarianWindow cw = new LibrarianWindow();
                        cw.Show();
                        this.Close();
                        j = 1;
                    }
                    if (us.fk_id_role == 2)
                    {
                        MessageBox.Show("Вы авторизованы");
                        AdminWindow cw = new AdminWindow();
                        cw.Show();
                        this.Close();
                        j = 1;
                    }
                }
                else
                {
                    i = 1;
                }
            }
            if (i == 1)
            {
                if (j == 0)
                {
                    MessageBox.Show("Ошибка авторизации! Повторите попытку");
                    Cap.Visibility = Visibility.Visible;
                    Capcha.Visibility = Visibility.Visible;
                }
            }
            

        }

    }
}
