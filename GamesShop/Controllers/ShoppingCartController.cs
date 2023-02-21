using GamesShop.Models;
using GamesShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;

        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IGameRepository gameRepository, IShoppingCart shoppingCart)
        {
            _gameRepository = gameRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);

        }

        public RedirectToActionResult AddToShoppingCart(int gameId)
        {
            var selectedGame = _gameRepository.AllGames.FirstOrDefault(g => g.Id == gameId);

            if (selectedGame != null)
            {
                _shoppingCart.AddToCart(selectedGame);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int gameId)
        {
            var selectedGame = _gameRepository.AllGames.FirstOrDefault(g => g.Id == gameId);
             
            if (selectedGame != null)
            {
                _shoppingCart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }
    } 
}
