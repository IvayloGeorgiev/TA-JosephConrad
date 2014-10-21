namespace AccountSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;

    using AccountSystem.Data.Migrations;
    using AccountSystem.Models;

    public class AccountSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public AccountSystemDbContext()
            : base("BankAccountSystemConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AccountSystemDbContext, Configuration>());
        }

        public IDbSet<Account> Accounts { get; set; }

        public IDbSet<Card> Cards { get; set; }

        public static AccountSystemDbContext Create()
        {
            return new AccountSystemDbContext();
        }
    }
}
