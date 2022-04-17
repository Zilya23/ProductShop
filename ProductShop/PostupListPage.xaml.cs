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
    /// Логика взаимодействия для PostupListPage.xaml
    /// </summary>
    public partial class PostupListPage : Page
    {
        public static ObservableCollection<DateBasee.ProductIntake> intakes { get; set; }
        public PostupListPage()
        {
            InitializeComponent();
            intakes = new ObservableCollection<DateBasee.ProductIntake>(bd_connection.connection.ProductIntake.ToList());
            this.DataContext = this;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListPage(ListPage.user));
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lv_postup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var n = (sender as ListView).SelectedItem as DateBasee.ProductIntake;

            NavigationService.Navigate(new IntakeRedPage(n));
        }
    }
}
