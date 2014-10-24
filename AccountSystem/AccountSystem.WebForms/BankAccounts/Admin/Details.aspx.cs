namespace AccountSystem.WebForms.BankAccounts.Admin
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using AccountSystem.Data;

    public partial class Details : System.Web.UI.Page
    {
        protected string ibanId;
        protected AccountSystemData data = new AccountSystemData(new AccountSystemDbContext());
        protected string username;        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("/");
            }
            
            ibanId = Request.QueryString["id"];
            if (ibanId == null)
            {
                Response.Redirect("/"); // TODO - error message.
            }

            var account = data.Accounts.All().Where(x => x.IBAN.ToString() == ibanId).FirstOrDefault();

            if (account == null)
            {
                Response.Redirect("/Users/Details");
            }

            username = account.Owner.UserName;

            if (!IsPostBack) 
            {
                LiteralCurrency.Text = account.CurrencyType.ToString();
                LiteralBalance.Text = account.Balance.ToString();
                LiteralOwner.Text = account.Owner.UserName;
                LabelStatus.Text = account.Status.ToString();
            }
        }

        protected void TransactionHistory_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/BankAccounts/TransactionHistory?id=" + ibanId);
        }

        protected void EditAccount_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/BankAccounts/Admin/Edit?id=" + ibanId);
        }
    }
}