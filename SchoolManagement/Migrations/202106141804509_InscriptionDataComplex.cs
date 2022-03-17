namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InscriptionDataComplex : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilliereEtudiants",
                c => new
                    {
                        Filliere_Id = c.Int(nullable: false),
                        Etudiant_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Filliere_Id, t.Etudiant_Id })
                .ForeignKey("dbo.Fillieres", t => t.Filliere_Id, cascadeDelete: true)
                .ForeignKey("dbo.Etudiants", t => t.Etudiant_Id, cascadeDelete: true)
                .Index(t => t.Filliere_Id)
                .Index(t => t.Etudiant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilliereEtudiants", "Etudiant_Id", "dbo.Etudiants");
            DropForeignKey("dbo.FilliereEtudiants", "Filliere_Id", "dbo.Fillieres");
            DropIndex("dbo.FilliereEtudiants", new[] { "Etudiant_Id" });
            DropIndex("dbo.FilliereEtudiants", new[] { "Filliere_Id" });
            DropTable("dbo.FilliereEtudiants");
        }
    }
}
