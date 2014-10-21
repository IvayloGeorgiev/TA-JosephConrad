namespace AccountSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Account> accounts;
        private ICollection<Card> cards;

        public ApplicationUser()
            : base()
        {
            this.accounts = new HashSet<Account>();
            this.cards = new HashSet<Card>();
            this.UserRole = UserRole.Client;
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

        public ClientInformation ClientInformation { get; set; }

        public UserRole UserRole { get; set; }

        public virtual ICollection<Account> Accounts
        {
            get { return this.accounts; }
            set { this.accounts = value; }
        }

        public virtual ICollection<Card> Cards
        {
            get { return this.cards; }
            set { this.cards = value; }
        }
    }
}
