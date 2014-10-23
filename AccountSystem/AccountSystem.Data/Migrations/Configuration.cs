namespace AccountSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using AccountSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AccountSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AccountSystemDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Client"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Client" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {UserName = "admin"};

                manager.Create(user, "admin1");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "pesho"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "pesho", Email = "pesho@pesho.com" };

                manager.Create(user, "pesho1");
                manager.AddToRole(user.Id, "Client");

                var acc = new BankAccount() { Balance = 521.25m, CurrencyType = CurrencyType.BGN, OwnerId = user.Id };
                context.Accounts.Add(acc);
                context.SaveChanges();

                var card = new Card() { CardNumber = "1234567890123456", CardStatus = CardStatus.Approved, CardType = CardType.MasterCard, ExpirationDate = new DateTime(2018, 5, 5), Pin = "0000", AccountId = acc.Id, OwnerId = user.Id };
                context.Cards.Add(card);
                context.SaveChanges();

            }

            if (!context.Users.Any(u => u.UserName == "gosho"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "gosho", Email = "gosho@gosho.com" };

                manager.Create(user, "gosho1");
                manager.AddToRole(user.Id, "Client");

                var acc = new BankAccount() { Balance = 100000m, CurrencyType = CurrencyType.BGN, OwnerId = user.Id };
                context.Accounts.Add(acc);
                context.SaveChanges();

                var card = new Card() { CardNumber = "9876543210012345", CardStatus = CardStatus.Approved, CardType = CardType.Visa, ExpirationDate = new DateTime(2019, 5, 5), Pin = "0000", AccountId = acc.Id, OwnerId = user.Id };
                context.Cards.Add(card);
                context.SaveChanges();
            }
        }
    }
}
