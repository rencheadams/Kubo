namespace QBO_Events_Management.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QBO_Events_Management.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "QBO_Events_Management.Models.ApplicationDbContext";
        }

        protected override void Seed(QBO_Events_Management.Models.ApplicationDbContext context)
        {
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
            context.Events.AddOrUpdate( i => i.Name,
                new Event
                {
                    Name = "Qlitan",
                    Details = "Qlitan",
                    Date = DateTime.Parse("2017-07-30"),
                    Time = TimeSpan.Parse("12:00:00"),
                    Venue = "QBO Innovation Hub",
                    Status = "Published"
                },

                new Event
                {
                    Name = "Qlitan3",
                    Details = "Qlitan3",
                    Date = DateTime.Parse("2017-09-30"),
                    Time = TimeSpan.Parse("12:00:00"),
                    Venue = "QBO Innovation Hub",
                    Status = "Unpublished"
                },

                new Event
                {
                    Name = "Qlitan4",
                    Details = "Qlitan4",
                    Date = DateTime.Parse("2017-10-30"),
                    Time = TimeSpan.Parse("12:00:00"),
                    Venue = "QBO Innovation Hub",
                    Status = "Published"
                },

               new Event
               {
                   Name = "Qlitan 2",
                   Details = "Qlitan 2",
                   Date = DateTime.Parse("2017-08-30"),
                   Time = TimeSpan.Parse("12:00:00"),
                   Venue = "QBO Innovation Hub",
                   Status = "Published"
               }

            );
        }
    }
}
