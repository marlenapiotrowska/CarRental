namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarRentalTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "CarRentalId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CarRentalId");
            Sql("INSERT INTO CarRentals (Id, Name) VALUES (0, 'JacksRental')");
            AddForeignKey("dbo.Cars", "CarRentalId", "dbo.CarRentals", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarRentalId", "dbo.CarRentals");
            DropIndex("dbo.Cars", new[] { "CarRentalId" });
            DropColumn("dbo.Cars", "CarRentalId");
            DropTable("dbo.CarRentals");
        }
    }
}
