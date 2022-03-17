namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneToManyClasseEtudiant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etudiants", "ClasseId", c => c.Int());
            CreateIndex("dbo.Etudiants", "ClasseId");
            AddForeignKey("dbo.Etudiants", "ClasseId", "dbo.Classes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Etudiants", new[] { "ClasseId" });
            DropColumn("dbo.Etudiants", "ClasseId");
        }
    }
}
