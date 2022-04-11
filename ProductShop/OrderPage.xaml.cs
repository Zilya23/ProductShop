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

namespace ProductShop
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage(DateBasee.User user)
        {
            InitializeComponent();


            //cb_prod.ItemsSource = bd_connection.connection.Product.ToList();
            //cb_prod.DisplayMemberPath = "Name";
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListPage(ListPage.user));
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
