using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccountSystem.Data.Repositories;
using AccountSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AccountSystem.Data
{
    public class AccountSystemData : IAccountSystemData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public AccountSystemData(AccountSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<BankAccount> Accounts
        {
            get { return this.GetRepository<BankAccount>(); }
        }

        public IRepository<Card> Cards
        {
            get { return this.GetRepository<Card>(); }
        }

        public IRepository<Transaction> Transactions
        {
            get { return this.GetRepository<Transaction>(); }
        }

        public IRepository<IdentityRole> Roles
        {
            get { return this.GetRepository<IdentityRole>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
