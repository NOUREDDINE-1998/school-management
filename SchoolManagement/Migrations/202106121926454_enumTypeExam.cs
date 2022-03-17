namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumTypeExam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Examen", "LibelleE", c => c.Int(nullable: false));
            DropColumn("dbo.Examen", "Libelle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Examen", "Libelle", c => c.String(nullable: false));
            DropColumn("dbo.Examen", "LibelleE");
        }
    }
}
