namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFilliereTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fillieres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        NiveauFormation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fillieres");
        }
    }
}
