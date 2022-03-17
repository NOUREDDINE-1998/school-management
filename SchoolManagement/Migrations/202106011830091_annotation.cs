namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etudiants", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Etudiants", "Photo", c => c.String(nullable: false));
        }
    }
}
