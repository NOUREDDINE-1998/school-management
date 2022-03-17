namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableOfReglement1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reglements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        Frais = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reglements");
        }
    }
}
