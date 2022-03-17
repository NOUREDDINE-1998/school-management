namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilliereEtudiants", "Filliere_Id", "dbo.Fillieres");
            DropForeignKey("dbo.FilliereEtudiants", "Etudiant_Id", "dbo.Etudiants");
            DropIndex("dbo.FilliereEtudiants", new[] { "Filliere_Id" });
            DropIndex("dbo.FilliereEtudiants", new[] { "Etudiant_Id" });
           
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
            
            CreateIndex("dbo.FilliereEtudiants", "Etudiant_Id");
            CreateIndex("dbo.FilliereEtudiants", "Filliere_Id");
            AddForeignKey("dbo.FilliereEtudiants", "Etudiant_Id", "dbo.Etudiants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilliereEtudiants", "Filliere_Id", "dbo.Fillieres", "Id", cascadeDelete: true);
        }
    }
}
