using ServiceCenter.Data.Interfaces;
using ServiceCenter.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCenter.Data.Repository
{
    public class DetailRepository : IDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public DetailRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IQueryable<Detail> Details => _context.Details;

        public async Task AddDetail(Detail detail)
        {
            await _context.Details.AddAsync(detail);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
