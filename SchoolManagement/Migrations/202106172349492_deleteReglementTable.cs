namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteReglementTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Reglements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reglements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        Frais = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
