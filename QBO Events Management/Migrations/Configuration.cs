namespace QBO_Events_Management.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using QBO_Events_Management.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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

			// Roles
			var roleStore = new RoleStore<IdentityRole>(context);
			var roleManager = new RoleManager<IdentityRole>(roleStore);

			if (!context.Roles.Any(r => r.Name == "Participant"))
			{
				var role = new IdentityRole { Name = "Participant" };
				roleManager.Create(role);
			}
			if (!context.Roles.Any(r => r.Name == "Admin"))
			{
				var role = new IdentityRole { Name = "Admin" };
				roleManager.Create(role);
			}

			// Accounts
			var userStore = new UserStore<ApplicationUser>(context);
			var userManager = new UserManager<ApplicationUser>(userStore);

			if (!context.Users.Any(u => u.UserName == "josephbrian@mailinator.com"))
			{
				var user = new ApplicationUser
				{
					UserName = "josephbrian@mailinator.com",
					FullName = "Joseph",
					Email = "josephbrian@mailinator.com",
					EmailConfirmed = true,
				};
				userManager.Create(user, "Testing@123");
				userManager.AddToRole(user.Id, "Admin");
			}

		}
    }
}
