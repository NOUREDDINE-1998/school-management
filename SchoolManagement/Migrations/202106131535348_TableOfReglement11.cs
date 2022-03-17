namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableOfReglement11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reglements", "Frais", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reglements", "Frais", c => c.Single(nullable: false));
        }
    }
}
