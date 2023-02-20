using System.ComponentModel;

namespace GamesShop.Models
{
    public class Game
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }     

        public string? LongDescription { get; set; }    

        public int YearReleased { get; set; }
        public decimal Price { get; set; }     

        public string? ImageName { get; set; }
        public string? ThumbnailImageName { get; set; }

        public bool IsGameOfTheWeek { get; set; } = false;

        public bool inStock { get; set; }

        public int PlatformId { get; set; } 

        public Platform Platform { get; set; } = default!;

    }
}
