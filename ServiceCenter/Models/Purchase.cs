using System;

namespace ServiceCenter.Models
{
    /// <summary>
    /// Покупка
    /// </summary>
    public class Purchase
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }

        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
