using System.Reflection.Metadata.Ecma335;

namespace GamesShop.Models
{
    public class MockGameRepository : IGameRepository
    {
        public readonly IPlatformRepository _platformRepository = new MockPlatformRepository();

        public IEnumerable<Game> AllGames =>
            new List<Game>
            { new Game { Id = 1, Name = "Minecraft", YearReleased = 2007, Price = 65, Description = "Lorem Ipsum",
                Platform= _platformRepository.AllPlatforms.ToList()[1], ThumbnailImageName = "minecraft-nsTh.jpg"},
            new Game { Id = 2, Name = "Sonic Forces", YearReleased = 2012, Price = 50, Description = "Lorem Ipsum",
            Platform= _platformRepository.AllPlatforms.ToList()[0], ThumbnailImageName = "sonic-forcesTh.jpg"},
            new Game { Id = 3, Name = "Plants Vs Zombies", YearReleased = 2011, Price = 50, Description = "Lorem Ipsum",
            Platform= _platformRepository.AllPlatforms.ToList()[1], ThumbnailImageName = "plantsVsZombiesTh.jpg"}
            };

        public IEnumerable<Game> GamesOfTheWeek
        { get
            {
             return AllGames.Where(g => g.IsGameOfTheWeek);
            } 
        }

        public Game? GetGameById(int id) =>
            //GetAll.Where(g => g.Id == id).FirstOrDefault();
            AllGames.FirstOrDefault(g => g.Id == id);
    }
}
