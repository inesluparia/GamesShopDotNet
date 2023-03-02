using GamesShop.Models;
using GamesShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesShop.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlatformRepository _platformRepository;

        public GameController(IGameRepository gameRepository, IPlatformRepository platformRepository)
        {
            _gameRepository = gameRepository;
            _platformRepository = platformRepository;
        }


        public IActionResult List(string platform)
        {
            //ViewBag.Test = "Hola from the view bag!";

            //return View(_gameRepository.AllGames);

            string? currentPlatform;
            IEnumerable<Game> games;

            if(string.IsNullOrEmpty(platform))
            {
                currentPlatform = "All Platforms";
                games = _gameRepository.AllGames.OrderBy(x => x.Name);

            } else
            {
                currentPlatform = _platformRepository.AllPlatforms.FirstOrDefault(p => p.PlatformName  == platform)?.PlatformName;
                games = _gameRepository.AllGames.Where(g => g.Platform.PlatformName == platform).OrderBy(g => g.Name);

            }

            return View(new GameListViewModel(games, currentPlatform));

        }

        public IActionResult Details(int id)
        {
            var game = _gameRepository.GetGameById(id);
            if (game == null)
                return NotFound();
            return View(game);
        }

    }
}
