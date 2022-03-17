namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationfraisReglament : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reglements", "Frais", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reglements", "Frais", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
