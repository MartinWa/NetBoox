using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace NetBoox.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext()
            : base("DefaultConnection")
        {
        }
        
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
    }


    [Table("Genre")]
    public class Genre
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }

    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int GenreId { get; set; }
    }
}