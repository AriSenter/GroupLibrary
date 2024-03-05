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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            listviewTovar.ItemsSource = Helper.context.BIBKA_Book.ToList();
            listviewChit.ItemsSource = Helper.context.BIBKA_User.ToList();
            listviewHis.ItemsSource = Helper.context.BIBKA_History.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddOrUpdateBook().ShowDialog();
            listviewTovar.ItemsSource = Helper.context.BIBKA_Book.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listviewTovar.SelectedItem is BIBKA_Book client)
            {
                new AddOrUpdateBook(client).ShowDialog();
                listviewTovar.ItemsSource = Helper.context.BIBKA_Book.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (listviewTovar.SelectedItem is BIBKA_Book client)
            {
                Helper.context.BIBKA_Book.Remove(client);
                Helper.context.SaveChanges();
                listviewTovar.ItemsSource = Helper.context.BIBKA_Book.ToList();
            }
        }
    }
}
