using AccountSystem.Data;
using AccountSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountSystem.WebForms.Users.Admin
{
    public partial class CardsDetails : System.Web.UI.Page
    {
        protected string cardId;
        private Card card;
        private IAccountSystemData data;
        private static Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("/");
            }

            cardId = Request.QueryString["id"];
            if (cardId == null)
            {
                Response.Redirect("/");
            }

            this.data = new AccountSystemData(new AccountSystemDbContext());
            this.card = data.Cards.Find(int.Parse(cardId));
            if (this.card == null)
            {
                Response.Redirect("/");
            }                        

            ExpirationDate.Text = card.ExpirationDate.Value.ToString();
            CardNumber.Text = card.CardNumber.ToString();
            LabelUserName.Text = card.Owner.UserName;
            LabelBalance.Text = card.Account.Balance.ToString();
            LabelCurrencyType.Text = card.Account.CurrencyType.ToString();
            LabelAccountStatus.Text = card.Account.Status.ToString();
            LabelCardStatus.Text = card.CardStatus.ToString();
            LabelCardType.Text = card.CardType.ToString();
        }

        protected void Approve(object sender, EventArgs e)
        {
            this.card.CardStatus = CardStatus.Approved;
            card.CardNumber = GenerateCardNumber();
            card.ExpirationDate = DateTime.Now.AddYears(2);
            Update();
        }
        protected void Decline(object sender, EventArgs e)
        {
            this.card.CardStatus = CardStatus.Rejected;
            card.CardNumber = "0000000000000000";
            card.ExpirationDate = DateTime.Now;
            Update();
        }

        private void Update()
        {
            ExpirationDate.Text = card.ExpirationDate.Value.ToString();
            CardNumber.Text = card.CardNumber.ToString();
            LabelCardStatus.Text = card.CardStatus.ToString();
            this.data.Cards.Update(card);
            this.data.SaveChanges();
        }

        private string GenerateCardNumber()
        {
            string result = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                result += rand.Next(0, 10).ToString();
            }
            return result;
        }
    }
}