using GamesShop.Models;

namespace GamesShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Game> GamesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Game> gamesOfTheWeek)
        {
            GamesOfTheWeek = gamesOfTheWeek;
        }
    }
}
