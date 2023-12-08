namespace Webshop.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }
    }
}
