namespace AccountSystem.WebForms.BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using AccountSystem.Data;
    using AccountSystem.Models;

    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected AccountSystemData data = new AccountSystemData(new AccountSystemDbContext());
        protected string ibanId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity == null)
            {
                Response.Redirect("/");
            }

            ibanId = Request.QueryString["id"];
            if (ibanId == null)
            {
                Response.Redirect("/"); // TODO - error message.
            }

            var curAccount = data.Accounts.All().Where(a => a.IBAN.ToString() == ibanId).FirstOrDefault();
            if (curAccount == null)
            {
                Response.Redirect("/");
            }

            if (curAccount.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                Response.Redirect("/");
            }
        }

        public IQueryable<AccountSystem.Models.Transaction> GridViewTransactions_GetData()
        {                        
            return this.data.Transactions.All().Where(t => t.Account.IBAN.ToString() == ibanId);
        }
    }
}