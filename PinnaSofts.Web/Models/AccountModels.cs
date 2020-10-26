using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PinnaSofts.Web.Models
{
    //public class UsersContext : DbContext
    //{
    //    public UsersContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //    //newly added
    //    public DbSet<webpages_Membership> webpages_Memberships { get; set; }
    //    public DbSet<webpages_Roles> webpages_Roles { get; set; }
    //    public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
    //}

    //[Table("UserProfile")]
    //public class UserProfile
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int UserId { get; set; }
    //    public string UserName { get; set; }
    //}
    //[Table("webpages_Roles")]
    //public class webpages_Roles
    //{
    //    [Key]
    //    public int RoleId { get; set; }
    //    public string RoleName { get; set; }
    //    public string RoleDescription { get; set; }
    //    public int? RoleCategory { get; set; }
    //    public string RoleForStatus { get; set; }

    //}

    //[Table("webpages_UsersInRoles")]
    //public class webpages_UsersInRoles
    //{
    //    [Key]
    //    [Column(Order = 0)]
    //    public int UserId { get; set; }
    //    [Key]
    //    [Column(Order = 1)]
    //    public int RoleId { get; set; }

    //    public UserProfile Users { get; set; }
    //    public webpages_Roles Roles { get; set; }

    //}

    //[Table("webpages_Membership")]
    //public class webpages_Membership
    //{
    //    [Key]
    //    public int UserId { get; set; }
    //    public DateTime CreateDate { get; set; }
    //    public string ConfirmationToken { get; set; }
    //    public bool IsConfirmed { get; set; }
    //    public DateTime LastPasswordFailureDate { get; set; }
    //    public int PasswordFailuresSinceLastSuccess { get; set; }
    //    public string Password { get; set; }
    //    public DateTime PasswordChangeDate { get; set; }
    //    public string PasswordSalt { get; set; }
    //    public string PasswordVerificationToken { get; set; }
    //    public DateTime PasswordVerificationTokenExpirationDate { get; set; }
    //}


    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
