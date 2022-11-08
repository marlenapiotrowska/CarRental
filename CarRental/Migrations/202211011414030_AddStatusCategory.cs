namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Status");
        }
    }
}
