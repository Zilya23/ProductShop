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
    /// Логика взаимодействия для IntakeRedPage.xaml
    /// </summary>
    public partial class IntakeRedPage : Page
    {
        public static ObservableCollection<DateBasee.ProductIntakeProduct> intakeProducts { get; set; }
        public IntakeRedPage(DateBasee.ProductIntake intake)
        {
            InitializeComponent();

            intakeProducts = new ObservableCollection<DateBasee.ProductIntakeProduct>((bd_connection.connection.ProductIntakeProduct.Where(n => n.ProductIntake.Id == intake.Id)).ToList());

            cb_supplier.SelectedItem = intake.Supplier.Name;

            cb_supplier.ItemsSource = bd_connection.connection.Supplier.ToList();
            cb_supplier.DisplayMemberPath = "Name";
            this.DataContext = this;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PostupListPage());
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
