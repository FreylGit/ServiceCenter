using ServiceCenter.Data.Interfaces;
using ServiceCenter.Models;
using System.Linq;

namespace ServiceCenter.Data.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;
        public IQueryable<Purchase> Purchases => _context.Purchases;
        public PurchaseRepository()
        {
            _context = new ApplicationDbContext();
        }



        public void AddPurchase(Product product, Customer customer)
        {
            var purchase = new Purchase()
            {
                Product = product,
                ProductId = product.Id,
                Customer = customer,
                CustomerId = customer.Id,
            };
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
