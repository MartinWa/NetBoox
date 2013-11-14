namespace NetBoox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "Genre_GenreId", "dbo.Genre");
            DropIndex("dbo.Book", new[] { "Genre_GenreId" });
            AddColumn("dbo.Book", "GenreId", c => c.Int(false));
            DropColumn("dbo.Book", "Genre_GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Genre_GenreId", c => c.Int());
            DropColumn("dbo.Book", "GenreId");
            CreateIndex("dbo.Book", "Genre_GenreId");
            AddForeignKey("dbo.Book", "Genre_GenreId", "dbo.Genre", "GenreId");
        }
    }
}
