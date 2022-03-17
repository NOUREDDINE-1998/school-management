namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addINscriptionTableAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateInscription = c.DateTime(nullable: false),
                        AnneeScolaire = c.String(),
                        NiveauScolarite = c.String(nullable: false),
                        Categorie = c.String(),
                        NiveauFormation = c.String(nullable: false),
                        EtudiantId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etudiants", t => t.EtudiantId)
                .Index(t => t.EtudiantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscriptions", "EtudiantId", "dbo.Etudiants");
            DropIndex("dbo.Inscriptions", new[] { "EtudiantId" });
            DropTable("dbo.Inscriptions");
        }
    }
}
