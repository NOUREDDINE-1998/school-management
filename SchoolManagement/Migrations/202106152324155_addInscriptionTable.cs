namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInscriptionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inscrptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EtudiantsId = c.String(maxLength: 128),
                        FillieresId = c.Int(nullable: false),
                        DateInscription = c.DateTime(nullable: false),
                        AnneeScolaire = c.String(),
                        NiveauScolarite = c.String(),
                        Categorie = c.String(),
                        NiveauFormation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etudiants", t => t.EtudiantsId)
                .ForeignKey("dbo.Fillieres", t => t.FillieresId, cascadeDelete: true)
                .Index(t => t.EtudiantsId)
                .Index(t => t.FillieresId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscrptions", "FillieresId", "dbo.Fillieres");
            DropForeignKey("dbo.Inscrptions", "EtudiantsId", "dbo.Etudiants");
            DropIndex("dbo.Inscrptions", new[] { "FillieresId" });
            DropIndex("dbo.Inscrptions", new[] { "EtudiantsId" });
            DropTable("dbo.Inscrptions");
        }
    }
}
