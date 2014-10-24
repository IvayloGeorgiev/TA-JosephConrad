using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using AccountSystem.Models;
using AccountSystem.Data;

namespace AccountSystem.WebForms.User
{
    public partial class AddAccount : System.Web.UI.Page
    {
        private IAccountSystemData appData;
        private string currentUserId;

        public AddAccount()
        {
            this.appData = new AccountSystemData(new AccountSystemDbContext());
            this.currentUserId = this.User.Identity.GetUserId();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListBoxCurrencyTypes.DataSource = CurrencyType.GetValues(typeof(CurrencyType)).Cast<CurrencyType>().Select((val, i) => new { Id = i, Name = val }).ToList();
                this.ListBoxCurrencyTypes.DataBind();
            }
        }

        protected void AddNewAccount(object sender, EventArgs e)
        {
            var fieldCurrencyType = this.ListBoxCurrencyTypes;
            if (fieldCurrencyType == null || string.IsNullOrEmpty(fieldCurrencyType.SelectedValue))
            {
                this.ErrorMessage.Text = "Incorrect currency type";
                return;
            }

            var currencyType = (CurrencyType)fieldCurrencyType.SelectedIndex;
            var currentUser = this.appData.Users.All().FirstOrDefault(u => u.Id == this.currentUserId);

            var newAccount = new BankAccount()
            {
                Owner = currentUser,
                CurrencyType = currencyType,                
                Balance = 0,
                Status = AccountStatus.Pending
            };
            currentUser.Accounts.Add(newAccount);
            this.appData.SaveChanges();

            Response.Redirect("~/BankAccounts/Details?id=" + newAccount.IBAN);
        }
    }
}