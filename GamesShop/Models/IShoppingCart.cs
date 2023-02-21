namespace GamesShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Game game);
        int RemoveFromCart(Game game);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
