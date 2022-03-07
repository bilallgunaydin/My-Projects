using WebApi.DBOperations;
using WebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
           context.Genres.AddRange(
                    new Genre { GenreName = "Dram" },
                    new Genre { GenreName = "Aksiyon" },
                    new Genre { GenreName = "Komedi" },
                    new Genre { GenreName = "Korku" },
                    new Genre { GenreName = "Romantik" },
                    new Genre { GenreName = "Bilim-Kurgu" }
            );
        }
    }

}