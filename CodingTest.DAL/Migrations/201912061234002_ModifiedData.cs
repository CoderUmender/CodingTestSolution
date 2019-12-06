namespace CodingTest.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Description", c => c.Int(nullable: false));
        }
    }
}
