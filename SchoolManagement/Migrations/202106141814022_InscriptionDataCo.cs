namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InscriptionDataCo : DbMigration
    {
        public override void Up()
        {
     
         
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
                        NiveauScolarite = c.String(),
                        Categorie = c.String(),
                        NiveauFormation = c.String(),
                        EtudiantId = c.String(),
                        FilliereId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Fillieres", "Inscrption_Id", c => c.Int());
            AddColumn("dbo.Etudiants", "Inscrption_Id", c => c.Int());
            CreateIndex("dbo.Fillieres", "Inscrption_Id");
            CreateIndex("dbo.Etudiants", "Inscrption_Id");
            AddForeignKey("dbo.Fillieres", "Inscrption_Id", "dbo.Inscrptions", "Id");
            AddForeignKey("dbo.Etudiants", "Inscrption_Id", "dbo.Inscrptions", "Id");
        }
    }
}
