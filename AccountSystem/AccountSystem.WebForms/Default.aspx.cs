namespace AccountSystem.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using AccountSystem.Data;
    using dbModels = AccountSystem.Models;

    public partial class _Default : Page
    {
        private IAccountSystemData appData;
        private string currentUserId;

        public _Default()
        {
            this.appData = new AccountSystemData(new AccountSystemDbContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbAccountsCount.Text = this.appData.Accounts.All().Count().ToString();
            this.lbCardsCount.Text = this.appData.Cards.All().Count().ToString();
            this.lbTransactionsCount.Text = this.appData.Transactions.All().Count().ToString();
            this.lbUsersCount.Text = this.appData.Users.All().Count().ToString();
        }
    }
}