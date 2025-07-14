using System.Reflection.Metadata.Ecma335;

namespace KatalogProduk.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public List<Product> Product { get; set; }
        public DateTime Orderdate { get; set; }
    }
}
