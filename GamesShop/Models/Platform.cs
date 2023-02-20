namespace GamesShop.Models
{
    public class Platform
    {

        public int PlatformId { get; set; }

        public string PlatformName { get; set; } = string.Empty;       

        public List<Game>? Games { get; set; }

    }
}
