namespace Hastane_yazilimi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hastane2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RandevuTables", "RandevuSaati", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RandevuTables", "RandevuSaati");
        }
    }
}
