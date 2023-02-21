using GamesShop.Models;
using GamesShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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


        public IActionResult List()
        {
            //ViewBag.Test = "Hola from the view bag!";
            //return View(_gameRepository.GetAll);
            
            GameListViewModel gameListViewModel = new GameListViewModel(_gameRepository.AllGames, "All games");
            return View(gameListViewModel);
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
