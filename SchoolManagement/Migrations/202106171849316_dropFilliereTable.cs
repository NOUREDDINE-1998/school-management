namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropFilliereTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Fillieres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Fillieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        NiveauFormation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
