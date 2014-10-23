using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;

using AccountSystem.Data;
using AccountSystem.Models;

namespace AccountSystem.WebForms.User
{
    public partial class AddCard : System.Web.UI.Page
    {
        private IAccountSystemData appData;
        private string currentUserId;

        public AddCard()
        {
            this.appData = new AccountSystemData(new AccountSystemDbContext());
            this.currentUserId = this.User.Identity.GetUserId();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListBoxBankAccounts.DataSource = this.appData.Accounts.All().Where(a => a.OwnerId == this.currentUserId).ToList();
                this.ListBoxBankAccounts.DataBind();

                this.ListBoxCardTypes.DataSource = CardType.GetValues(typeof(CardType)).Cast<CardType>().Select((val, i) => new { Id = i, Name = val }).ToList();
                this.ListBoxCardTypes.DataBind();
            }
        }

        protected void AddNewCard(object sender, EventArgs e)
        {
            var fieldCardType = this.ListBoxCardTypes;
            var fieldPassword = this.tbPassword;
            var fieldBankAccount = this.ListBoxBankAccounts;

            if (fieldCardType == null || fieldPassword == null || fieldBankAccount == null)
            {
                //Empty input
            }

            var cardType = (CardType)fieldCardType.SelectedIndex;
            var selectedPassword = fieldPassword.Text;
            var accountIban = fieldBankAccount.SelectedItem.Text;
            var currentUser = this.appData.Users.All().FirstOrDefault(u => u.Id == this.currentUserId);

            var selectedAccount = currentUser.Accounts.FirstOrDefault(a => a.IBAN.ToString() == accountIban);
            if (selectedAccount == null)
            {
                //Missing or not account to this user
            }
            else if (cardType == null)
            {
                //Invalid card type
            }
            else if (String.IsNullOrEmpty(selectedPassword) || selectedPassword.Length < 4 || selectedPassword.Length > 6)
            {
                //Invalid password
            }

            var newCard = new Card()
            {
                Pin = selectedPassword,
                CardType = cardType,
                Owner = currentUser,
                Account = selectedAccount
            };

            currentUser.Cards.Add(newCard);
            this.appData.SaveChanges();

            Response.Redirect("~/User/Cards");
        }
    }
}