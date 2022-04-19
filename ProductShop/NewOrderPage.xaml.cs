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
using System.Collections.ObjectModel;

namespace ProductShop
{
    /// <summary>
    /// Логика взаимодействия для NewOrderPage.xaml
    /// </summary>
    public partial class NewOrderPage : Page
    {
        public static ObservableCollection<DateBasee.ProductOrder> productsOrder { get; set; }
        //public static DateBasee.Order order;
        public static int Count = 0;
        DateBasee.Order NewOrderID = new DateBasee.Order();
        public NewOrderPage()
        {
            InitializeComponent();
            //productsOrder = new ObservableCollection<DateBasee.ProductOrder>((bd_connection.connection.ProductOrder.Where(a => a.OrderId == order.Id)).ToList());
            cb_prod.ItemsSource = bd_connection.connection.Product.ToList();
            cb_prod.DisplayMemberPath = "Name";
            this.DataContext = this;

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage(ListPage.user));
        }

        public void UpdateProd()
        {
          dg_newOrder.ItemsSource = bd_connection.connection.ProductOrder.Where(a => a.OrderId == NewOrderID.Id).ToList();
        }
        private void btn_prod_Click(object sender, RoutedEventArgs e)
        {
           
            if (Count == 0)
            {
                NewOrderID = bd_connection.connection.Order.Add(new DateBasee.Order
                {
                    Date = DateTime.Now,
                    StatusOrderId = 1,
                    ClientId = ListPage.user.Id

                }) ;
                bd_connection.connection.SaveChanges();
                //order.ClientId = ListPage.user.Id;
                //order.StatusOrder = 1;
                //order.Date = DateTime.Now;
                //bd_connection.connection.Order.Add(order);
                Count++;
            }
            if (cb_prod.SelectedIndex >= 0 && tb_alown.Text != null)
            {
                var ProdOrder = new DateBasee.ProductOrder();
                var selectProd = cb_prod.SelectedItem as DateBasee.Product;
                ProdOrder.ProductId = selectProd.Id;
                ProdOrder.OrderId = NewOrderID.Id;
                ProdOrder.Count = Convert.ToInt32(tb_alown.Text);
                var isProduct = bd_connection.connection.ProductOrder.Where(a => a.ProductId == selectProd.Id && a.OrderId == NewOrderID.Id).Count();
                if (isProduct == 0)
                {
                    bd_connection.connection.ProductOrder.Add(ProdOrder);
                    bd_connection.connection.SaveChanges();
                    UpdateProd();
                }
            }
        }
    }
}
