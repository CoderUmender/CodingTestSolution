namespace CodingTest.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RmvedDataAnotatin : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Locations", name: "LocationId", newName: "Location_Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Locations", name: "Location_Id", newName: "LocationId");
        }
    }
}
