using ServiceCenter.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCenter.Data.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        public IQueryable<Product> Products { get; }
        public Task AddProductAsync(Product product);
        public Task<Product> GetProductByNameAsync(string name);

    }
}
