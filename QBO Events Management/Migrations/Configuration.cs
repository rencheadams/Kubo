namespace QBO_Events_Management.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using Microsoft.AspNet.Identity.EntityFramework;
	using QBO_Events_Management.Models;
	using Microsoft.AspNet.Identity;

	internal sealed class Configuration : DbMigrationsConfiguration<QBO_Events_Management.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
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

			//context.Roles.AddOrUpdate(r => r.Name,
			//	new IdentityRole { Name = "Admin" },
			//	new IdentityRole { Name = "Member" }

			//);

			//var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			//UserManager.AddToRole("a55e2957-9052-4e25-8ecd-65ec2f1b496f","Admin");

			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			if (UserManager.FindByEmail("enveloperedseven@outlook.com") == null)
			{
				var testEmail = new ApplicationUser() { EmailConfirmed = true, Email = "enveloperedseven@outlookcom", UserName = "enveloperedseven@outlook.com" };
				UserManager.Create(testEmail, "Testing@123");
				UserManager.AddToRole(testEmail.Id, "Admin");
			}

		}
    }
}
