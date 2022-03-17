namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overRidingdata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etudiants", "Adresse", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Etudiants", "Adresse", c => c.String());
        }
    }
}
