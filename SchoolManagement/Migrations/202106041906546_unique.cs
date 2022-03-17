namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etudiants", "Tel", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Etudiants", "Tel", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Etudiants", new[] { "Tel" });
            AlterColumn("dbo.Etudiants", "Tel", c => c.String(nullable: false));
        }
    }
}
