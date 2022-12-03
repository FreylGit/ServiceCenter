using ServiceCenter.Data;
using ServiceCenter.Data.Interfaces;
using ServiceCenter.Data.Repository;
using ServiceCenter.Models;
using System.Windows;

namespace ServiceCenter.Windows
{
    /// <summary>
    /// Логика взаимодействия для SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IServiceRepository _serviceRepository;
        private Product _product;

        public SellWindow(Product product)
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
            _purchaseRepository = new PurchaseRepository();
            _serviceRepository = new ServiceRepository();
            _product = product;
            TotalPrice.Content = "К оплате:" + product.Price.ToString("C");
        }

        private void SellBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerNumber.Text != "")
            {
                var customer = _customerRepository.GetByNumber(CustomerNumber.Text);
                if (customer != null)
                {
                    _customerRepository.Dispose();
                    Shopping(customer);
                    Close();
                }
            }
            else
            {
                if (RegisterName.Text != "" && RegisterNumber.Text != "")
                {
                    var customer = new Customer()
                    {
                        Name = RegisterName.Text,
                        Number = RegisterNumber.Text,
                    };
                    _customerRepository.AddCustomer(customer);
                    Shopping(customer);
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void Shopping(Customer customer)
        {
            using (var context = new ApplicationDbContext())
            {
                Purchase purchase = new Purchase()
                {
                    CustomerId = customer.Id,
                    ProductId = _product.Id
                };
                context.Purchases.Add(purchase);
                context.SaveChanges();
            }
            _serviceRepository.AddingMoney(_product.Price);
            MessageBox.Show("Покупка совершилась");

        }
    }
}
