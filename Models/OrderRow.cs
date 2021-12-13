public class OrderRow {
    public int id { get; set; }
    public int orderId { get; set; }
    public int productId { get; set; }
    public string product { get; set; }
    public int amount { get; set; }
    public Order order { get; set; }
    public Product Product { get; set; }
}