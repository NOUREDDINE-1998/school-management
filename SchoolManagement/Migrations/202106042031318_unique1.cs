namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Etudiants", new[] { "Tel" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Etudiants", "Tel", unique: true);
        }
    }
}
