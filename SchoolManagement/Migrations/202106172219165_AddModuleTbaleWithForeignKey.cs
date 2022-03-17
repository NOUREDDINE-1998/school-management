namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModuleTbaleWithForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                        Coefficient = c.Byte(nullable: false),
                        TotalHeures = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
           
            
            AddColumn("dbo.Examen", "TypeExamen", c => c.String(nullable: false));
            AddColumn("dbo.Examen", "ClasseId", c => c.Int());
            AddColumn("dbo.Examen", "ModuleId", c => c.Int());
            CreateIndex("dbo.Examen", "ClasseId");
            CreateIndex("dbo.Examen", "ModuleId");
            AddForeignKey("dbo.Examen", "ClasseId", "dbo.Classes", "Id");
            AddForeignKey("dbo.Examen", "ModuleId", "dbo.Modules", "Id");
            DropColumn("dbo.Examen", "LibelleE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Examen", "LibelleE", c => c.String(nullable: false));
            DropForeignKey("dbo.Examen", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Examen", "ClasseId", "dbo.Classes");
            DropForeignKey("dbo.ModuleClasses", "Classe_Id", "dbo.Classes");
            DropForeignKey("dbo.ModuleClasses", "Module_Id", "dbo.Modules");
            DropIndex("dbo.ModuleClasses", new[] { "Classe_Id" });
            DropIndex("dbo.ModuleClasses", new[] { "Module_Id" });
            DropIndex("dbo.Examen", new[] { "ModuleId" });
            DropIndex("dbo.Examen", new[] { "ClasseId" });
            DropColumn("dbo.Examen", "ModuleId");
            DropColumn("dbo.Examen", "ClasseId");
            DropColumn("dbo.Examen", "TypeExamen");
            DropTable("dbo.ModuleClasses");
            DropTable("dbo.Modules");
        }
    }
}
