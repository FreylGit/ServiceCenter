using ServiceCenter.Data.Interfaces;
using ServiceCenter.Data.Repository;
using ServiceCenter.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ServiceCenter.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateDetailWindow.xaml
    /// </summary>
    public partial class CreateDetailWindow : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly IDetailRepository _detailRepository;
        public delegate void Render();
        public event Render RenderStart;
        public CreateDetailWindow()
        {
            InitializeComponent();
            _productRepository = new ProductRepository();
            _detailRepository = new DetailRepository();
            var names = _productRepository.Products.Select(p => p.Name);
            foreach (var name in names)
            {
                Technique.Items.Add(new ComboBoxItem().Content = name);

            }
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var price = this.Price.Text;

            string techniqueName = Technique.Text;

            if (name != null && techniqueName != null && price != null)
            {
                var product = await _productRepository.GetProductByNameAsync(techniqueName);
                var detail = new Detail
                {
                    Name = name,
                    Price = Convert.ToDecimal(price),
                    ProductId = product.Id,
                };
                await _detailRepository.AddDetail(detail);
            }
            Close();
            RenderStart.Invoke();
            _productRepository.Dispose();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            _productRepository.Dispose();
        }
    }
}
