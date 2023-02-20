using GamesShop.Models;
using GamesShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public HomeController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Game> gamesOfTheWeek = _gameRepository.GamesOfTheWeek;
            HomeViewModel homeViewModel = new HomeViewModel(gamesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
