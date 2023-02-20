using GamesShop.Models;

namespace GamesShop.ViewModels
{
    public class GameListViewModel
    {
        public GameListViewModel(IEnumerable<Game> games, string? currentPlatform)
        {
            Games = games;
            CurrentPlatform = currentPlatform;
        }

        public IEnumerable<Game> Games { get; }
          
        public string? CurrentPlatform { get; }

        
    }
}
