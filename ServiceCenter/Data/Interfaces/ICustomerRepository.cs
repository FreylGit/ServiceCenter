using ServiceCenter.Models;
using System;
using System.Linq;

namespace ServiceCenter.Data.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {
        IQueryable<Customer> Customers { get; }
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
        public Customer GetByNumber(string number);

    }
}
