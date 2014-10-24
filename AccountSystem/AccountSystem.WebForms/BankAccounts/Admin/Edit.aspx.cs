namespace AccountSystem.WebForms.BankAccounts.Admin
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

    public partial class Edit : System.Web.UI.Page
    {
        protected string ibanId;
        AccountSystemData data = new AccountSystemData(new AccountSystemDbContext());

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

            var values = Enum.GetValues(typeof(AccountStatus));

            AccountStatusField.DataSource = values;
            AccountStatusField.DataBind();
            AccountStatusField.SelectedIndex = (int)account.Status.GetTypeCode();

            BalanceField.Text = account.Balance.ToString();
        }

        protected void EditAccount_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var currentStatus = (AccountStatus)Enum.Parse(typeof(AccountStatus), AccountStatusField.SelectedValue, true);

                var account = data.Accounts.All().Where(x => x.IBAN.ToString() == ibanId).FirstOrDefault();
                account.Balance = decimal.Parse(BalanceField.Text);
                account.Status = currentStatus;
                
                data.Accounts.Update(account);
                data.SaveChanges();

                Response.Redirect("/Users/Admin/UserDetails?id=" + account.OwnerId);
            }
        }

        protected void DecimalValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                decimal.Parse(args.Value);
                args.IsValid = true;
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }
    }
}