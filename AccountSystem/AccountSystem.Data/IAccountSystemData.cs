namespace AccountSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AccountSystem.Data.Repositories;
    using AccountSystem.Models;

    public interface IAccountSystemData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Account> Accounts { get; }

        IRepository<Card> Cards { get; }

        int SaveChanges();
    }
}
