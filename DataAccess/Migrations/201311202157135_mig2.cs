namespace NetBoox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Author", c => c.String());
            AddColumn("dbo.Book", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Rating");
            DropColumn("dbo.Book", "Author");
        }
    }
}
