namespace SchoolManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaiementTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.paiements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EtudiantId = c.String(nullable: false, maxLength: 128),
                        TypeReglement = c.String(nullable: false),
                        TypePaiement = c.String(),
                        DureeEnMois = c.Byte(nullable: false),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatePaiment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etudiants", t => t.EtudiantId, cascadeDelete: true)
                .Index(t => t.EtudiantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.paiements", "EtudiantId", "dbo.Etudiants");
            DropIndex("dbo.paiements", new[] { "EtudiantId" });
            DropTable("dbo.paiements");
        }
    }
}
