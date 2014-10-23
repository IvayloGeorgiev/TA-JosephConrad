using AccountSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace AccountSystem.WebForms.BankAccounts
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Client"))
            {
                var ibanId = Request.QueryString["id"];
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
                else
                {
                    LabelCurrency.Text = account.CurrencyType.ToString();
                    LabelBalance.Text = account.Balance.ToString();
                    LabelOwner.Text = account.Owner.UserName;
                    var userCards = account.Owner.Cards.ToList();
                }
            }
        }
    }
}