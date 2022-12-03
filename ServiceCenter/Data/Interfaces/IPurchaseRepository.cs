using ServiceCenter.Models;
using System;
using System.Linq;

namespace ServiceCenter.Data.Interfaces
{
    public interface IPurchaseRepository : IDisposable
    {
        public IQueryable<Purchase> Purchases { get; }
        public void AddPurchase(Product product, Customer customer);

    }
}
