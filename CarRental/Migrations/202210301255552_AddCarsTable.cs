namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Brand = c.String(),
                        Color = c.String(),
                        ProductionYear = c.Int(nullable: false),
                        EnginePower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
