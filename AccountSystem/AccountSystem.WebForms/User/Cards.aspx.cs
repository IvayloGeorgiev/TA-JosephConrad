using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountSystem.Data;
using AccountSystem.Models;

namespace AccountSystem.WebForms.User
{
    public partial class Cards : System.Web.UI.Page
    {
        private IAccountSystemData appData;

        public Cards()
        {
            this.appData = new AccountSystemData(new AccountSystemDbContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AccountSystem.Models.Card> GridViewCards_GetData()
        {
            if (this.appData.Cards.All().FirstOrDefault(c => c.Owner.UserName == this.User.Identity.Name) == null)
            {
                var currentUser = this.appData.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
                var newAccount = new BankAccount()
                {
                    Owner = currentUser,
                    Balance = 5
                };
                currentUser.Accounts.Add(newAccount);
                var newCard = new Card()
                {
                    Pin = "1234",
                    CardNumber = "9234567891234567",
                    ExpirationDate = DateTime.Now.AddDays(10),
                    Account = newAccount,
                    Owner = newAccount.Owner
                };

                newAccount.Cards.Add(newCard);
                this.appData.SaveChanges();
            }

            return this.appData.Cards.All().AsQueryable<Card>();
        }

        protected void CardDetails_Command(object sender, CommandEventArgs e)
        {
            var cardId = e.CommandArgument;
            Response.Redirect("~/User/Card/" + cardId);
        }
    }
}