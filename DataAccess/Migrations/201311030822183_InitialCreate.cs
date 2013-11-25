namespace NetBoox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Genre_GenreId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Genre", t => t.Genre_GenreId)
                .Index(t => t.Genre_GenreId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Book", new[] { "Genre_GenreId" });
            DropForeignKey("dbo.Book", "Genre_GenreId", "dbo.Genre");
            DropTable("dbo.Book");
            DropTable("dbo.Genre");
        }
    }
}
