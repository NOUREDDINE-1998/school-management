namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libelleE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Examen", "LibelleE", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Examen", "LibelleE", c => c.Int(nullable: false));
        }
    }
}
