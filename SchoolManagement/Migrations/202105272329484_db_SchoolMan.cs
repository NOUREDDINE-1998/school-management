namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_SchoolMan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Date_Nai_Etu = c.DateTime(nullable: false),
                        Adresse = c.String(),
                        Email = c.String(),
                        Tel = c.String(),
                        Sexe = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Etudiants");
        }
    }
}
