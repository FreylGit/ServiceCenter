using ServiceCenter.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCenter.Data.Interfaces
{
    public interface IDetailRepository : IDisposable
    {
        public IQueryable<Detail> Details { get; }
        public Task AddDetail(Detail detail);

    }
}
