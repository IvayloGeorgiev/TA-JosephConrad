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

    public partial class Transfer : System.Web.UI.Page
    {
        protected string ibanId;
        AccountSystemData data = new AccountSystemData(new AccountSystemDbContext());

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

            if (curAccount.Status != AccountStatus.Active)
            {
                Response.Redirect("/BankAccounts/Details?id=" + ibanId);
            }
        }

        protected void TransferFunds_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                decimal amount = decimal.Parse(AmountField.Text); ;                

                var curAccount = data.Accounts.All().Where(a => a.IBAN.ToString() == ibanId).FirstOrDefault();               

                var newTransaction = new Transaction() { AccountId = curAccount.Id, Amount = -amount, Reason = ReasonField.Text, TargetIban = TargetIBANField.Text, TimeOfTransaction = DateTime.Now };
                curAccount.Balance -= amount;
                data.Transactions.Add(newTransaction);
                data.Accounts.Update(curAccount);

                data.SaveChanges();

                Response.Redirect("/BankAccounts/Details?id=" + ibanId);
            }
        }

        protected void IbanLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                string Iban = args.Value;
                args.IsValid = Iban.Length > 30;
            }
            catch (Exception ex)
            {
                args.IsValid = false;
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

        protected void AccountBalanceCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                var curAccount = data.Accounts.All().Where(a => a.IBAN.ToString() == ibanId).FirstOrDefault();
                decimal amount = decimal.Parse(args.Value);
                args.IsValid = curAccount.Balance > amount;
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }
    }
}