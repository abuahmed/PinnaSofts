using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using PinnaSofts.Entity;
using PinnaSofts.Entity.Models;
using PinnaSofts.DAL.Mappings;
using PinnaSofts.Entity.Enumerations;

namespace PinnaSofts.DAL
{
    public class PinnaSoftsDbContext : DbContextBase
    {
        public PinnaSoftsDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            Database.SetInitializer<PinnaSoftsDbContext>(new MigrateDatabaseToLatestVersion<PinnaSoftsDbContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new MembershipMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UsersInRolesMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class DbContextFactory : IDbContextFactory<PinnaSoftsDbContext>
    {
        public PinnaSoftsDbContext Create()
        {
            string SQlServConString = "data source=.;initial catalog=PinnaSoftsDb;user id=sa;password=amihan";
            SqlConnectionFactory sql = new SqlConnectionFactory(SQlServConString);
            return new PinnaSoftsDbContext(sql.CreateConnection(SQlServConString), true);
        }
    }
    public class Configuration : DbMigrationsConfiguration<PinnaSoftsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PinnaSoftsDbContext context)
        {
            IList<webpages_Roles> ListOfRoles = new List<webpages_Roles>();

            #region Seed Roles
            ListOfRoles.Add(new webpages_Roles() { RoleDescription = RoleTypes.Admin.ToString(), RoleName = RoleTypes.Admin.ToString() });
            ListOfRoles.Add(new webpages_Roles() { RoleDescription = RoleTypes.ViewReports.ToString(), RoleName = RoleTypes.ViewReports.ToString() });
            #endregion

            #region Seed Users
            context.Set<UserProfile>().Add(new UserProfile()
            {
                UserId = 1,
                UserName = "admin"

            });
            context.Set<webpages_Membership>().Add(new webpages_Membership()
            {
                UserId = 1,
                Password = "admin5!",
                IsConfirmed = true,
                CreateDate = DateTime.Now,
                PasswordSalt = "amihanSalt"

            });
            foreach (webpages_Roles role in ListOfRoles)
            {
                context.Set<webpages_UsersInRoles>().Add(new webpages_UsersInRoles()
                {
                    Roles = role,
                    UserId = 1
                });
            }
            #endregion

            base.Seed(context);
        }
    }

    class DbInitializer : DropCreateDatabaseIfModelChanges<PinnaSoftsDbContext>//DropCreateDatabaseAlwaysDropCreateDatabaseIfModelChanges
    {
        protected override void Seed(PinnaSoftsDbContext context)
        {
            base.Seed(context);
        }
    }


}
