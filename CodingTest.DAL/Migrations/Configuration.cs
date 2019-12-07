namespace CodingTest.DAL.Migrations
{
    using CodingTest.BAL.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodingTest.DAL.HierarichyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CodingTest.DAL.HierarichyContext";
        }

        protected override void Seed(CodingTest.DAL.HierarichyContext context)
        {
          // context.Departments.Add(new Department  () { Description= "Bakery", Location_ID =3 });
           // context.Locations.Add(new Location  () { Description= "Perimeter" });
            // context.Categories.Add(new Category() { Description= "Bakery Bread", Department_ID=1});
            context.SubCategories.Add(new SubCategory() { Description = "Bagels", Category_Id = 1 });
            context.SaveChanges();
           
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
