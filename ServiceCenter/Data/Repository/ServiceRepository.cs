using ServiceCenter.Data.Interfaces;
using System.Linq;

namespace ServiceCenter.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public decimal TotalPrice => _context.Services.First().TotalMoney;

        public ServiceRepository()
        {
            _context = new ApplicationDbContext();
        }
        public void AddingMoney(decimal money)
        {
            var s = _context.Services.First();
            s.TotalMoney += money;
            _context.Services.Update(s);
            _context.SaveChanges();
        }

        public void DecreasingMoney(decimal money)
        {
            var s = _context.Services.FirstOrDefault();
            s.TotalMoney -= money;
            _context.Services.Update(s);
            _context.SaveChanges();
        }

        public decimal GetCurrentTotalMoney()
        {
            return _context.Services.FirstOrDefault().TotalMoney;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
