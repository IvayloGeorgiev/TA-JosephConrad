namespace AccountSystem.WebForms.BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using AccountSystem.Data;
    using AccountSystem.Models;

    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected AccountSystemData data = new AccountSystemData(new AccountSystemDbContext());
        protected string accountId;

        protected void Page_Load(object sender, EventArgs e)
        {
            accountId = Request.QueryString["id"];
            if (accountId == null)
            {
                Response.Redirect("/BankAccounts/Details"); // TODO - error message.
            }  
        }

        public IQueryable<AccountSystem.Models.Transaction> GridViewTransactions_GetData()
        {                        
            return this.data.Transactions.All();
        }
    }
}