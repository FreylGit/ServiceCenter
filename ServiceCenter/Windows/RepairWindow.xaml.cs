using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data.Interfaces;
using ServiceCenter.Data.Repository;
using ServiceCenter.Models;
using System.Linq;
using System.Windows;

namespace ServiceCenter.Windows
{
    /// <summary>
    /// Логика взаимодействия для RepairWindow.xaml
    /// </summary>
    public partial class RepairWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly IServiceRepository _serviceRepository;
        private decimal _totalPrice = 0;
        public RepairWindow()
        {
            _customerRepository = new CustomerRepository();
            _purchaseRepository = new PurchaseRepository();
            _productRepository = new ProductRepository();
            _detailRepository = new DetailRepository();
            _serviceRepository = new ServiceRepository();
            InitializeComponent();
        }
        private void InitDetailsList(Customer customer)
        {
            var productId = _purchaseRepository.Purchases.FirstOrDefault(p => p.CustomerId == customer.Id).ProductId;
            var product = _productRepository.Products.Include(p => p.Details).FirstOrDefault(p => p.Id == productId);
            foreach (var item in product.Details)
            {
                ListDetails.Items.Add(item.Name);
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var number = Number.Text;
            var customer = _customerRepository.GetByNumber(number);
            TotalPrice.Content = customer.Name;
            InitDetailsList(customer);
        }


        private void ListDetails_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string curItem = ListDetails.SelectedItem.ToString();
            ListDetailsRepair.Items.Add(curItem);
            var price = _detailRepository.Details.FirstOrDefault(p => p.Name == curItem).Price;
            CountTotalPrice(price);
            TotalPrice.Content = "Стоимость ремонта:" + _totalPrice.ToString("C");
        }

        private void CountTotalPrice(decimal money)
        {
            _totalPrice += money;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _serviceRepository.AddingMoney(_totalPrice);
            Close();
        }
    }
}
