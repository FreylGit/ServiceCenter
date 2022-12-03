using ServiceCenter.Models;
using System.Linq;
using System.Windows;

namespace ServiceCenter.Windows
{
    /// <summary>
    /// Логика взаимодействия для InformationProductWindow.xaml
    /// </summary>
    public partial class InformationProductWindow : Window
    {

        private Product _product;

        public InformationProductWindow(Product product)
        {
            InitializeComponent();
            _product = product;
            SetDataInView();
        }

        private void SetDataInView()
        {
            Name.Content = "Название:" + _product.Name;
            Description.Content = "Описание:" + _product.Description;
            Category.Content = "Категория:" + _product.Category;
            Price.Content = "Цена:" + _product.Price;
            Amount.Content = "Количество деталей:" + _product.Details.Count();
            Quantity.Content = "Количество на складе: " + _product.Quantity.ToString();
            SetListDetails();
        }
        private void SetListDetails()
        {
            var names = _product.Details.Select(d => d.Name);
            foreach (var name in names)
            {
                ListDetails.Items.Add(name);
            }
        }



        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            SellWindow window = new SellWindow(_product);

            window.Show();
            Close();
        }

        private void RepairBtn_Click(object sender, RoutedEventArgs e)
        {
            RepairWindow window = new RepairWindow();
            window.Show();
            Close();
        }
    }
}
