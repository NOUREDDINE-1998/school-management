namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoteTableWithManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EtudiantId = c.String(nullable: false, maxLength: 128),
                        ExamenId = c.Int(nullable: false),
                        NoteExamen = c.Single(nullable: false),
                        Mention = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.ExamenId, t.EtudiantId })
                .ForeignKey("dbo.Etudiants", t => t.EtudiantId, cascadeDelete: true)
                .ForeignKey("dbo.Examen", t => t.ExamenId, cascadeDelete: true)
                .Index(t => t.EtudiantId)
                .Index(t => t.ExamenId);
            
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Notes", "EtudiantId", "dbo.Etudiants");
            DropForeignKey("dbo.ExamenEtudiants", "Etudiant_Id", "dbo.Etudiants");
            DropForeignKey("dbo.ExamenEtudiants", "Examen_Id", "dbo.Examen");
            DropIndex("dbo.ExamenEtudiants", new[] { "Etudiant_Id" });
            DropIndex("dbo.ExamenEtudiants", new[] { "Examen_Id" });
            DropIndex("dbo.Notes", new[] { "ExamenId" });
            DropIndex("dbo.Notes", new[] { "EtudiantId" });
            DropTable("dbo.ExamenEtudiants");
            DropTable("dbo.Notes");
        }
    }
}
