using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using PinnaSofts.Entity.Models;

namespace PinnaSofts.DAL.Mappings
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            Property(t => t.UserName)
               .IsRequired()
               .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("UserProfile");
        }
    }
    public class MembershipMap : EntityTypeConfiguration<webpages_Membership>
    {
        public MembershipMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties          

            // Table & Column Mappings
            ToTable("webpages_Membership");
        }
    }
    public class RoleMap : EntityTypeConfiguration<webpages_Roles>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            Property(t => t.RoleDescription)
               .IsRequired();

            // Table & Column Mappings
            ToTable("webpages_Roles");

            //Relationships
        }
    }
    public class UsersInRolesMap : EntityTypeConfiguration<webpages_UsersInRoles>
    {
        public UsersInRolesMap()
        {
            // Primary Key
            //this.HasKey(t => {t.RoleId,t.UserId});

            // Properties
            //Property(t => t.RoleDescription)
            // .IsRequired();

            // Table & Column Mappings
            ToTable("webpages_UsersInRoles");

            //Relationships
            
        }
    }
}
