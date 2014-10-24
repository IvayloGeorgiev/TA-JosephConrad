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
        protected string ibanId;

        protected void Page_Load(object sender, EventArgs e)
        {
            ibanId = Request.QueryString["id"];
            if (ibanId == null)
            {
                Response.Redirect("/BankAccounts/Details"); // TODO - error message.
            }  
        }

        public IQueryable<AccountSystem.Models.Transaction> GridViewTransactions_GetData()
        {                        
            return this.data.Transactions.All().Where(t => t.Account.IBAN.ToString() == ibanId);
        }
    }
}