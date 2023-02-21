using Microsoft.EntityFrameworkCore;

namespace GamesShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly GameShopDbContext _gameShopDbContext;
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(GameShopDbContext gameShopDbContext)
        {
            _gameShopDbContext = gameShopDbContext;
        }


        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            GameShopDbContext context = services.GetService<GameShopDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Game game)
        {
            var shoppingCartItem = _gameShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Game.Id == game.Id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null) 
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Game = game,
                    Amount = 1
                };

                _gameShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _gameShopDbContext.SaveChanges();
        }
        public int RemoveFromCart(Game game)
        {
            var localAmount = 0;
            
            var shoppingCartItem = _gameShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Game.Id == game.Id && s.ShoppingCartId == s.ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                { 
                    _gameShopDbContext.ShoppingCartItems.Remove(shoppingCartItem); _gameShopDbContext.SaveChanges();
                }
            }
            _gameShopDbContext.SaveChanges();

            return localAmount;
        }

        public void ClearCart()
        {
            var cartItems = _gameShopDbContext
                            .ShoppingCartItems
                            .Where(s => s.ShoppingCartId == ShoppingCartId);

            _gameShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _gameShopDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            //null coalescing asignment operator, how would the items list be in sync like this???
            return ShoppingCartItems ??=
                      _gameShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                          .Include(s => s.Game)
                          .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _gameShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                 .Select(c => c.Game.Price * c.Amount).Sum();
            return total;
        }

    }
}
