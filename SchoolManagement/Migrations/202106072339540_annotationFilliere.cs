namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationFilliere : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fillieres", "Libelle", c => c.String(nullable: false));
            AlterColumn("dbo.Fillieres", "NiveauFormation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fillieres", "NiveauFormation", c => c.String());
            AlterColumn("dbo.Fillieres", "Libelle", c => c.String());
        }
    }
}
