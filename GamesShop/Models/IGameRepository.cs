namespace GamesShop.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> AllGames { get; }

        IEnumerable<Game> GamesOfTheWeek { get; }

        Game? GetGameById(int id);
    }
}
