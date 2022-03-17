namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InscriptionOneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilliereEtudiants", "Filliere_Id", "dbo.Fillieres");
            DropForeignKey("dbo.FilliereEtudiants", "Etudiant_Id", "dbo.Etudiants");
            DropForeignKey("dbo.Inscrptions", "FillieresId", "dbo.Fillieres");
            DropIndex("dbo.Inscrptions", new[] { "FillieresId" });
            DropIndex("dbo.FilliereEtudiants", new[] { "Filliere_Id" });
            DropIndex("dbo.FilliereEtudiants", new[] { "Etudiant_Id" });
            RenameColumn(table: "dbo.Inscrptions", name: "EtudiantsId", newName: "EtudiantId");
            RenameIndex(table: "dbo.Inscrptions", name: "IX_EtudiantsId", newName: "IX_EtudiantId");
            DropColumn("dbo.Inscrptions", "FillieresId");
            DropTable("dbo.FilliereEtudiants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilliereEtudiants",
                c => new
                    {
                        Filliere_Id = c.Int(nullable: false),
                        Etudiant_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Filliere_Id, t.Etudiant_Id });
            
            AddColumn("dbo.Inscrptions", "FillieresId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Inscrptions", name: "IX_EtudiantId", newName: "IX_EtudiantsId");
            RenameColumn(table: "dbo.Inscrptions", name: "EtudiantId", newName: "EtudiantsId");
            CreateIndex("dbo.FilliereEtudiants", "Etudiant_Id");
            CreateIndex("dbo.FilliereEtudiants", "Filliere_Id");
            CreateIndex("dbo.Inscrptions", "FillieresId");
            AddForeignKey("dbo.Inscrptions", "FillieresId", "dbo.Fillieres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilliereEtudiants", "Etudiant_Id", "dbo.Etudiants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilliereEtudiants", "Filliere_Id", "dbo.Fillieres", "Id", cascadeDelete: true);
        }
    }
}
