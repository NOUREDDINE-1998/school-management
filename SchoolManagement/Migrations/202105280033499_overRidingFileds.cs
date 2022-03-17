namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overRidingFileds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etudiants", "Nom", c => c.String(nullable: false));
            AlterColumn("dbo.Etudiants", "Prenom", c => c.String(nullable: false));
            AlterColumn("dbo.Etudiants", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Etudiants", "Tel", c => c.String(nullable: false));
            AlterColumn("dbo.Etudiants", "Sexe", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Etudiants", "Sexe", c => c.String());
            AlterColumn("dbo.Etudiants", "Tel", c => c.String());
            AlterColumn("dbo.Etudiants", "Email", c => c.String());
            AlterColumn("dbo.Etudiants", "Prenom", c => c.String());
            AlterColumn("dbo.Etudiants", "Nom", c => c.String());
        }
    }
}
