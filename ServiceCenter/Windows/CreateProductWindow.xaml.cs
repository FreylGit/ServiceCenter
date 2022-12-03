using ServiceCenter.Data.Interfaces;
using ServiceCenter.Data.Repository;
using ServiceCenter.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ServiceCenter.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateProductWindow.xaml
    /// </summary>
    public partial class CreateProductWindow : Window
    {
        private readonly IProductRepository _productRepository;

        public delegate void Render();
        public event Render RenderStart;

        public CreateProductWindow()
        {
            _productRepository = new ProductRepository();
            InitializeComponent();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            var name = this.Name.Text;
            var description = this.Description.Text;
            ComboBoxItem item = (ComboBoxItem)this.Category.SelectedItem;
            string category = null;
            if (item != null)
            {
                category = item.Content.ToString();
            }

            var price = this.Price.Text;

            if (name != null && description != null && category != null && price != null)
            {
                var product = new Product
                {
                    Name = name,
                    Description = description,
                    Category = category,
                    Price = Convert.ToDecimal(price)
                };

                await _productRepository.AddProductAsync(product);

                RenderStart.Invoke();
                _productRepository.Dispose();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
