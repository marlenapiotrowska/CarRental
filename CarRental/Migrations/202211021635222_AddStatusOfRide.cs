namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusOfRide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "StatusOfRide", c => c.Int(nullable: false));            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "StatusOfRide");
        }
    }
}
