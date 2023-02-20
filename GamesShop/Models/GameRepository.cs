using Microsoft.EntityFrameworkCore;

namespace GamesShop.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly GameShopDbContext _dBcontext;

        public GameRepository(GameShopDbContext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public IEnumerable<Game> AllGames
        {
            get
            {
                return _dBcontext.Games.Include(e => e.Platform);
            }
        }

        public IEnumerable<Game> GamesOfTheWeek
        {
            get
            {
                return _dBcontext.Games.Include(e => e.Platform).Where(g => g.IsGameOfTheWeek);
            }
        }
        

        public Game? GetGameById(int id)
        {
            return _dBcontext.Games.FirstOrDefault(g => g.Id == id);
        }
    }
}
