namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.ReglementEtudiants",
                 c => new
                 {
                     Reglement_Id = c.Int(nullable: false),
                     Etudiant_Id = c.String(nullable: false, maxLength: 128),
                 })
                 .PrimaryKey(t => new { t.Reglement_Id, t.Etudiant_Id });

            CreateTable(
                "dbo.FilliereEtudiants",
                c => new
                {
                    Filliere_Id = c.Int(nullable: false),
                    Etudiant_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.Filliere_Id, t.Etudiant_Id });

            CreateTable(
                "dbo.EtudiantClasses",
                c => new
                {
                    Etudiant_Id = c.String(nullable: false, maxLength: 128),
                    Classe_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Etudiant_Id, t.Classe_Id });

            CreateIndex("dbo.ReglementEtudiants", "Etudiant_Id");
            CreateIndex("dbo.ReglementEtudiants", "Reglement_Id");
            CreateIndex("dbo.FilliereEtudiants", "Etudiant_Id");
            CreateIndex("dbo.FilliereEtudiants", "Filliere_Id");

            AddForeignKey("dbo.ReglementEtudiants", "Etudiant_Id", "dbo.Etudiants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReglementEtudiants", "Reglement_Id", "dbo.Reglements", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilliereEtudiants", "Etudiant_Id", "dbo.Etudiants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilliereEtudiants", "Filliere_Id", "dbo.Fillieres", "Id", cascadeDelete: true);




        }

        public override void Down()
        {
            CreateTable(
                "dbo.ReglementEtudiants",
                c => new
                    {
                        Reglement_Id = c.Int(nullable: false),
                        Etudiant_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Reglement_Id, t.Etudiant_Id });
            
            CreateTable(
                "dbo.FilliereEtudiants",
                c => new
                    {
                        Filliere_Id = c.Int(nullable: false),
                        Etudiant_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Filliere_Id, t.Etudiant_Id });
            
            CreateTable(
                "dbo.EtudiantClasses",
                c => new
                    {
                        Etudiant_Id = c.String(nullable: false, maxLength: 128),
                        Classe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Etudiant_Id, t.Classe_Id });
            
            CreateIndex("dbo.ReglementEtudiants", "Etudiant_Id");
            CreateIndex("dbo.ReglementEtudiants", "Reglement_Id");
            CreateIndex("dbo.FilliereEtudiants", "Etudiant_Id");
            CreateIndex("dbo.FilliereEtudiants", "Filliere_Id");
        
            AddForeignKey("dbo.ReglementEtudiants", "Etudiant_Id", "dbo.Etudiants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReglementEtudiants", "Reglement_Id", "dbo.Reglements", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilliereEtudiants", "Etudiant_Id", "dbo.Etudiants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilliereEtudiants", "Filliere_Id", "dbo.Fillieres", "Id", cascadeDelete: true);
         
        }
    }
}
