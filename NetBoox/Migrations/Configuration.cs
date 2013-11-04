namespace NetBoox.Migrations
{
    using NetBoox.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NetBoox.Models.BooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NetBoox.Models.BooksContext context)
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
