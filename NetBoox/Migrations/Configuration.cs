using DataAccess;
using Domain;

namespace NetBoox.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BooksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Genres.AddOrUpdate(
              g => g.GenreName,
              new Genre { GenreName = "Drama" },
              new Genre { GenreName = "Mystery" },
              new Genre { GenreName = "Action" }
            );
            //
        }
    }
}
