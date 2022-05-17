namespace Hastane_yazilimi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hastane1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KlinikTables", "KlinikAd", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KlinikTables", "KlinikAd", c => c.Int(nullable: false));
        }
    }
}
