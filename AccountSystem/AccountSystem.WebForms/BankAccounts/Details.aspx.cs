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

    public partial class Details : System.Web.UI.Page
    {
        protected string ibanId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Client"))
            {
                ibanId = Request.QueryString["id"];
                if (ibanId == null)
                {
                    Response.Redirect("/");
                }

                var data = new AccountSystemData(new AccountSystemDbContext());

                var account = data.Accounts.All().Where(x => x.IBAN.ToString() == ibanId).FirstOrDefault();

                if (account == null)
                {
                    Response.Redirect("/Users/Details");
                }

                if (account.OwnerId != User.Identity.GetUserId())
                {
                    Response.Redirect("/");
                }
               
                LiteralCurrency.Text = account.CurrencyType.ToString();
                LiteralBalance.Text = account.Balance.ToString();
                LiteralOwner.Text = account.Owner.UserName;
                LabelStatus.Text = account.Status.ToString();
                var userCards = account.Owner.Cards.ToList();                
            }

            else
            {
                Response.Redirect("/");
            }
        }

        protected void TransactionHistory_Command(object sender, CommandEventArgs e)
        {            
            Response.Redirect("~/BankAccounts/TransactionHistory?id=" + ibanId);
        }

        protected void Transfer_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/BankAccounts/Transfer?id=" + ibanId);
        }
    }
}