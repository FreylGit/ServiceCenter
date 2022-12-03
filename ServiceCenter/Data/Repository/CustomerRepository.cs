using ServiceCenter.Data.Interfaces;
using ServiceCenter.Models;
using System.Linq;

namespace ServiceCenter.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IQueryable<Customer> Customers => _context.Customers;

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Customer GetByNumber(string number)
        {
            return _context.Customers.FirstOrDefault(x => x.Number == number);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
