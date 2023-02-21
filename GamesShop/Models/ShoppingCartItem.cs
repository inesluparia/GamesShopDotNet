namespace GamesShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Game Game { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }


    }
}
