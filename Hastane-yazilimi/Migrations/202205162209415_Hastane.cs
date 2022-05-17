namespace Hastane_yazilimi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hastane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoktorTables",
                c => new
                    {
                        DoktorId = c.Int(nullable: false, identity: true),
                        DoktorTC = c.String(),
                        DoktorAd = c.String(),
                        DoktorSoyad = c.String(),
                        UnvanId = c.String(),
                        Cinsiyet = c.Boolean(nullable: false),
                        TelNo = c.String(),
                        Email = c.String(),
                        PoliklinikId = c.String(),
                        Poliklinik_PoliklinikId = c.Int(),
                        Unvan_UnvanId = c.Int(),
                    })
                .PrimaryKey(t => t.DoktorId)
                .ForeignKey("dbo.PolikinlikTables", t => t.Poliklinik_PoliklinikId)
                .ForeignKey("dbo.UnvanTables", t => t.Unvan_UnvanId)
                .Index(t => t.Poliklinik_PoliklinikId)
                .Index(t => t.Unvan_UnvanId);
            
            CreateTable(
                "dbo.PolikinlikTables",
                c => new
                    {
                        PoliklinikId = c.Int(nullable: false, identity: true),
                        PoliklinikAd = c.String(),
                        KlinikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PoliklinikId)
                .ForeignKey("dbo.KlinikTables", t => t.KlinikId, cascadeDelete: true)
                .Index(t => t.KlinikId);
            
            CreateTable(
                "dbo.KlinikTables",
                c => new
                    {
                        KlinikId = c.Int(nullable: false, identity: true),
                        KlinikAd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KlinikId);
            
            CreateTable(
                "dbo.RandevuTables",
                c => new
                    {
                        SıraNo = c.Int(nullable: false, identity: true),
                        RandevuNo = c.Int(nullable: false),
                        HastaId = c.Int(nullable: false),
                        DoktorId = c.Int(nullable: false),
                        RandevuDurumu = c.Boolean(nullable: false),
                        RandevuTarihi = c.DateTime(nullable: false),
                        Aciklama = c.String(),
                        IslemId = c.Int(nullable: false),
                        FaturaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SıraNo)
                .ForeignKey("dbo.DoktorTables", t => t.DoktorId, cascadeDelete: true)
                .ForeignKey("dbo.FaturaTables", t => t.FaturaId, cascadeDelete: true)
                .ForeignKey("dbo.HastaTables", t => t.HastaId, cascadeDelete: true)
                .ForeignKey("dbo.IslemTables", t => t.IslemId, cascadeDelete: true)
                .Index(t => t.HastaId)
                .Index(t => t.DoktorId)
                .Index(t => t.IslemId)
                .Index(t => t.FaturaId);
            
            CreateTable(
                "dbo.FaturaTables",
                c => new
                    {
                        FaturaId = c.Int(nullable: false, identity: true),
                        FaturaTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaturaTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaId);
            
            CreateTable(
                "dbo.HastaTables",
                c => new
                    {
                        HastaId = c.Int(nullable: false, identity: true),
                        HastaTC = c.String(),
                        HastaAd = c.String(),
                        HastaSoyad = c.String(),
                        Cinsiyet = c.Boolean(nullable: false),
                        TelNo = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.HastaId);
            
            CreateTable(
                "dbo.IslemTables",
                c => new
                    {
                        IslemId = c.Int(nullable: false, identity: true),
                        IslemAd = c.String(),
                        IslemUcret = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IslemId);
            
            CreateTable(
                "dbo.UnvanTables",
                c => new
                    {
                        UnvanId = c.Int(nullable: false, identity: true),
                        UnvanAd = c.String(),
                    })
                .PrimaryKey(t => t.UnvanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoktorTables", "Unvan_UnvanId", "dbo.UnvanTables");
            DropForeignKey("dbo.RandevuTables", "IslemId", "dbo.IslemTables");
            DropForeignKey("dbo.RandevuTables", "HastaId", "dbo.HastaTables");
            DropForeignKey("dbo.RandevuTables", "FaturaId", "dbo.FaturaTables");
            DropForeignKey("dbo.RandevuTables", "DoktorId", "dbo.DoktorTables");
            DropForeignKey("dbo.PolikinlikTables", "KlinikId", "dbo.KlinikTables");
            DropForeignKey("dbo.DoktorTables", "Poliklinik_PoliklinikId", "dbo.PolikinlikTables");
            DropIndex("dbo.RandevuTables", new[] { "FaturaId" });
            DropIndex("dbo.RandevuTables", new[] { "IslemId" });
            DropIndex("dbo.RandevuTables", new[] { "DoktorId" });
            DropIndex("dbo.RandevuTables", new[] { "HastaId" });
            DropIndex("dbo.PolikinlikTables", new[] { "KlinikId" });
            DropIndex("dbo.DoktorTables", new[] { "Unvan_UnvanId" });
            DropIndex("dbo.DoktorTables", new[] { "Poliklinik_PoliklinikId" });
            DropTable("dbo.UnvanTables");
            DropTable("dbo.IslemTables");
            DropTable("dbo.HastaTables");
            DropTable("dbo.FaturaTables");
            DropTable("dbo.RandevuTables");
            DropTable("dbo.KlinikTables");
            DropTable("dbo.PolikinlikTables");
            DropTable("dbo.DoktorTables");
        }
    }
}
