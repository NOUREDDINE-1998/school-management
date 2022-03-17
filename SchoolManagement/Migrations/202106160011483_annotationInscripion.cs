namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationInscripion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inscrptions", "EtudiantsId", "dbo.Etudiants");
            DropIndex("dbo.Inscrptions", new[] { "EtudiantsId" });
            AlterColumn("dbo.Inscrptions", "EtudiantsId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Inscrptions", "NiveauScolarite", c => c.String(nullable: false));
            AlterColumn("dbo.Inscrptions", "NiveauFormation", c => c.String(nullable: false));
            CreateIndex("dbo.Inscrptions", "EtudiantsId");
            AddForeignKey("dbo.Inscrptions", "EtudiantsId", "dbo.Etudiants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscrptions", "EtudiantsId", "dbo.Etudiants");
            DropIndex("dbo.Inscrptions", new[] { "EtudiantsId" });
            AlterColumn("dbo.Inscrptions", "NiveauFormation", c => c.String());
            AlterColumn("dbo.Inscrptions", "NiveauScolarite", c => c.String());
            AlterColumn("dbo.Inscrptions", "EtudiantsId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Inscrptions", "EtudiantsId");
            AddForeignKey("dbo.Inscrptions", "EtudiantsId", "dbo.Etudiants", "Id");
        }
    }
}
