namespace GamesShop.Models
{
    public class MockPlatformRepository : IPlatformRepository
    {
        public IEnumerable<Platform> AllPlatforms =>
            new List<Platform>
            {
                new Platform {PlatformId=1, PlatformName="PS4" },
                new Platform {PlatformId=2,PlatformName= "Switch"},
                new Platform {PlatformId=3,PlatformName="Xbox"}
            };
    }
}
