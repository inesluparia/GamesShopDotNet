namespace GamesShop.Models
{
    public interface IPlatformRepository
    {
       IEnumerable<Platform> AllPlatforms { get; }
    }
}
