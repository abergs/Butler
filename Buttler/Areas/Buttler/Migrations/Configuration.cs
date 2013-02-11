namespace Buttler.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Buttler.Areas.Buttler.Models;
    using WebMatrix.WebData;
    using System.Web.Security;

    internal sealed class Configuration : DbMigrationsConfiguration<ButtlerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ButtlerContext context)
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

            SeedMembership();
        }

        private void SeedMembership()
        {
            WebSecurityConfig.InitializeDatabaseConnection();

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "randompass");
            }

            if (!roles.GetRolesForUser("admin").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });
            }
        }
    }
}
