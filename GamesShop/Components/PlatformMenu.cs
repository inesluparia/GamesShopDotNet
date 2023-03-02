using GamesShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesShop.Components
{
    public class PlatformMenu : ViewComponent
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformMenu(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public IViewComponentResult Invoke()
        {
            var platforms = _platformRepository.AllPlatforms;
            return View(platforms);

        }
    }
}
