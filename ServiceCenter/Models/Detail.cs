namespace ServiceCenter.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
