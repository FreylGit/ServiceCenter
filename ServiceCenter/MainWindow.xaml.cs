using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data;
using ServiceCenter.Data.Interfaces;
using ServiceCenter.Data.Repository;
using ServiceCenter.Models;
using ServiceCenter.Windows;
using System.Linq;
using System.Windows;

namespace ServiceCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly IDetailRepository _detailRepository;
        private readonly IServiceRepository _serviceRepository;

        delegate void Render();

        public MainWindow()
        {
            InitializeComponent();

            _productRepository = new ProductRepository();
            _detailRepository = new DetailRepository();
            _serviceRepository = new ServiceRepository();
            using (var context = new ApplicationDbContext())
            {
                if (context.Services.FirstOrDefault() == null)
                {
                    context.Services.Add(new Service { TotalMoney = 0 });
                    context.SaveChanges();
                }
            }
            TotalMoney.Content = "Текущее количество денег: " + _serviceRepository.GetCurrentTotalMoney().ToString("C");


            RenderListProduct();
            RenderListDetail();

            ListTechniques.SelectionChanged += ListTechniques_SelectedIndexChanged;
        }

        private void CreateDetailBtn(object sender, RoutedEventArgs e)
        {
            CreateDetailWindow window = new CreateDetailWindow();
            window.RenderStart += RenderListDetail;
            window.Show();
        }

        private void CreateTechniqueBtn(object sender, RoutedEventArgs e)
        {
            CreateProductWindow window = new CreateProductWindow();
            window.RenderStart += RenderListProduct;
            window.Show();
        }

        private async void ListTechniques_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string curItem = ListTechniques.SelectedItem.ToString();
            var product = _productRepository.Products.Include(p => p.Details).FirstOrDefault(p => p.Name == curItem);

            InformationProductWindow window = new InformationProductWindow(product);
            window.Show();
        }

        public void RenderListProduct()
        {
            ListTechniques.Items.Clear();
            var productNames = _productRepository.Products.Select(p => p.Name);
            //Заполняем список имен техники
            foreach (var name in productNames)
            {
                ListTechniques.Items.Add(name);
            }
        }

        public void RenderListDetail()
        {
            ListDetails.Items.Clear();
            var detailNemes = _detailRepository.Details.Select(d => d.Name).Distinct();
            //Запоняем список имен деталей
            foreach (var name in detailNemes)
            {
                ListDetails.Items.Add(name);
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var money = context.Services.First().TotalMoney;
                TotalMoney.Content = "Текущее количество денег: " + money.ToString("c");
            }
        }
    }
}
