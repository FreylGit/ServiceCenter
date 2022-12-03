using System;

namespace ServiceCenter.Data.Interfaces
{
    public interface IServiceRepository : IDisposable
    {
        public decimal TotalPrice { get; }
        public void AddingMoney(decimal money);
        public void DecreasingMoney(decimal money);
        public decimal GetCurrentTotalMoney();
    }
}
