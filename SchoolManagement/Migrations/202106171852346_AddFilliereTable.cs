namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilliereTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fillieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Inscriptions", "FilliereId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inscriptions", "FilliereId");
            AddForeignKey("dbo.Inscriptions", "FilliereId", "dbo.Fillieres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscriptions", "FilliereId", "dbo.Fillieres");
            DropIndex("dbo.Inscriptions", new[] { "FilliereId" });
            DropColumn("dbo.Inscriptions", "FilliereId");
            DropTable("dbo.Fillieres");
        }
    }
}
