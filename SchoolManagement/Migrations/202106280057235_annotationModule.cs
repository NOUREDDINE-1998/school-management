namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationModule : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modules", "Libelle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modules", "Libelle", c => c.String());
        }
    }
}
