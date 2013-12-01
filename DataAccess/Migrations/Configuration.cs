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
            context.Books.AddOrUpdate(
                b => b.BookName,
                new Book { BookName = "Othello", GenreId = 1, Author = "William Shakespeare", Rating = 5 },
                new Book { BookName = "Romeo and Juliet", GenreId = 1, Author = "William Shakespeare", Rating = 5 },
                new Book { BookName = "The Perils of Sherlock Holmes", GenreId = 2, Author = "Arthur Conan Doyle", Rating = 5 },
                new Book { BookName = "Inferno", GenreId = 2, Author = "Dan Brown", Rating = 5 },
                new Book { BookName = "Patriot Games", GenreId = 3, Author = "Tom Clancy", Rating = 5 }
                );
        }
    }
}
