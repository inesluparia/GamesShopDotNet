namespace GamesShop.Models.Database
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            GameShopDbContext dBcontext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GameShopDbContext>();

            if (!dBcontext.Platforms.Any())
            {
                dBcontext.Platforms.AddRange(Platforms.Select(c => c.Value));
            }

            if (!dBcontext.Games.Any())
            {
                dBcontext.AddRange(
                    new Game
                    {
                        Id = 1,
                        Name = "Minecraft",
                        YearReleased = 2007,
                        Price = 65,
                        Description = "Lorem Ipsum",
                        Platform = Platforms["Switch"],
                        ThumbnailImageName = "minecraft-nsTh.jpg",
                        ImageName = "minecraft-ns.jpg"
                    },
                    new Game
                    {
                        Id = 2,
                        Name = "Sonic Forces",
                        YearReleased = 2012,
                        Price = 45,
                        Description = "Lorem Ipsum",
                        Platform = Platforms["PS4"],
                        ThumbnailImageName = "sonic-forcesTh.jpg",
                        ImageName = "sonic-forces.jpg"
                    },
                    new Game
                    {
                        Id = 3,
                        Name = "Plants Vs Zombies",
                        YearReleased = 2011,
                        Price = 50,
                        Description = "Lorem Ipsum",
                        Platform = Platforms["Switch"],
                        ThumbnailImageName = "plantsVsZombiesTh.jpg",
                        ImageName = "plantsVsZombies.jpg"
                    },
                    new Game
                    {
                        Id = 4,
                        Name = "Plants Vs Zombies",
                        YearReleased = 2011,
                        Price = 50,
                        Description = "Lorem Ipsum",
                        Platform = Platforms["Xbox"],
                        ThumbnailImageName = "plantsVsZombiesTh.jpg",
                        ImageName = "plantsVsZombies.jpg"
                    }

                );
            }
            dBcontext.SaveChanges();
        }

        private static Dictionary<string, Platform>? platforms;

        public static Dictionary<string, Platform> Platforms
        {
            get
            {
                if (platforms == null)
                {
                    var platList = new Platform[]
                    {
                        new Platform { PlatformName = "PS4" },
                        new Platform { PlatformName = "Switch" },
                        new Platform { PlatformName = "Xbox" }
                    };

                    platforms = new Dictionary<string, Platform>();

                    foreach (Platform p in platList)
                    {
                        platforms.Add(p.PlatformName, p);
                    }
                }

                return platforms;
            }
        }

    }
}
