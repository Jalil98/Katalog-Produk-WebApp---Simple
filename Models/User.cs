namespace KatalogProduk.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<CartItem> OrderHistory { get; set; } = new();
    }
}
