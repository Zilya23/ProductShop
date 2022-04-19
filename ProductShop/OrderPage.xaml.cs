using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection<DateBasee.Order> orders { get; set; }
        public OrderPage(DateBasee.User user)
        {
            InitializeComponent();
            orders = new ObservableCollection<DateBasee.Order>(bd_connection.connection.Order.ToList());
            this.DataContext = this;
      
            //if(ListPage.user.Id != 3)
            //{
            //    btn_save.Visibility = Visibility.Hidden;
            //}
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListPage(ListPage.user));
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewOrderPage());
        }

        private void dgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
