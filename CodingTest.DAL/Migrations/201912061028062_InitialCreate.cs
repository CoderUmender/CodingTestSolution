namespace CodingTest.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Department_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Category_Id)
                .ForeignKey("dbo.Departments", t => t.Department_ID, cascadeDelete: true)
                .Index(t => t.Department_ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Department_Id = c.Int(nullable: false, identity: true),
                        Description = c.Int(nullable: false),
                        Location_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Department_Id)
                .ForeignKey("dbo.Locations", t => t.Location_ID, cascadeDelete: true)
                .Index(t => t.Location_ID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Location_Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Location_Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategory_Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategory_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Departments", "Location_ID", "dbo.Locations");
            DropForeignKey("dbo.Categories", "Department_ID", "dbo.Departments");
            DropIndex("dbo.SubCategories", new[] { "Category_Id" });
            DropIndex("dbo.Departments", new[] { "Location_ID" });
            DropIndex("dbo.Categories", new[] { "Department_ID" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.Locations");
            DropTable("dbo.Departments");
            DropTable("dbo.Categories");
        }
    }
}
