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
    /// Логика взаимодействия для AddOrUpdateBook.xaml
    /// </summary>
    public partial class AddOrUpdateBook : Window
    {
        public AddOrUpdateBook()
        {
            InitializeComponent();
            DataContext = new BIBKA_Book();
        }
        public AddOrUpdateBook(BIBKA_Book client)
        {
            InitializeComponent();
            DataContext = client;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is BIBKA_Book client && client.id_book == 0)
            {
                Helper.context.BIBKA_Book.Add(client);
            }
            Helper.context.SaveChanges();
            Close();
        }
    }
}
