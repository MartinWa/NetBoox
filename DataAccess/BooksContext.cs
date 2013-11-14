using System.Data.Entity;
using Domain;

namespace DataAccess
{
    public class BooksContext : DbContext, IBooksContext
    {
        public BooksContext(): base("DefaultConnection"){}
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}