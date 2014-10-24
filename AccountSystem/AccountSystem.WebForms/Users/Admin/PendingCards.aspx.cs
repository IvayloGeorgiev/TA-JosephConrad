using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountSystem.Data;
using AccountSystem.Models;

namespace AccountSystem.WebForms.Users.Admin
{
    public partial class PendingCards : System.Web.UI.Page
    {
        private IAccountSystemData appData;

        public PendingCards()
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
            return this.appData.Cards.All().Where(x => x.CardStatus == CardStatus.Pending).AsQueryable<Card>();
        }

        protected void CardDetails_Command(object sender, CommandEventArgs e)
        {
            var cardId = e.CommandArgument;
            Response.Redirect("~/Users/Admin/CardsDetails?id=" + cardId);
        }
    }
}