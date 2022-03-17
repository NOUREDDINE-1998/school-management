namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationAnneeScolaire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inscriptions", "AnneeScolaire", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inscriptions", "AnneeScolaire", c => c.String());
        }
    }
}
