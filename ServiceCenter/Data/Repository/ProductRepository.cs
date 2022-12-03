using Microsoft.EntityFrameworkCore;
using ServiceCenter.Data.Interfaces;
using ServiceCenter.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCenter.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public IQueryable<Product> Products => _context.Products;
        public ProductRepository()
        {
            _context = new ApplicationDbContext();
        }


        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            var product = await _context.Products.Include(p => p.Details).FirstOrDefaultAsync(x => x.Name == name);
            return product;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
