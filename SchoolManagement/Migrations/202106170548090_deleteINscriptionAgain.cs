namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteINscriptionAgain : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Inscrptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Inscrptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateInscription = c.DateTime(nullable: false),
                        AnneeScolaire = c.String(),
                        NiveauScolarite = c.String(nullable: false),
                        Categorie = c.String(),
                        NiveauFormation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
