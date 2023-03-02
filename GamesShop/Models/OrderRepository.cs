using GamesShop.Models.Database;

namespace GamesShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GameShopDbContext _gameShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(GameShopDbContext gameShopDbContext, IShoppingCart shoppingCart)
        {
            _gameShopDbContext = gameShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Game.Id,
                    Price = shoppingCartItem.Game.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _gameShopDbContext.Orders.Add(order);

            _gameShopDbContext.SaveChanges();
        }
    }
}
