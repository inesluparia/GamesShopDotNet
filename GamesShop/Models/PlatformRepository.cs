namespace GamesShop.Models
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly GameShopDbContext _dBcontext;

        public PlatformRepository(GameShopDbContext dBcontext) {
            _dBcontext = dBcontext;
        }

        public IEnumerable<Platform> AllPlatforms =>
            _dBcontext.Platforms.OrderBy(p => p.PlatformName);
    }
}
