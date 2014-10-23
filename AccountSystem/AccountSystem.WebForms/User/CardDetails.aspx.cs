using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountSystem.WebForms.User
{
    public partial class CardDetails : System.Web.UI.Page
    {
        public int CardId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string cardIdParam = RouteData.Values["cardId"] as string;
            int parsedCardId;
            var isParsable = int.TryParse(cardIdParam, out parsedCardId);
            if (cardIdParam == null || !isParsable)
            {
                Response.Redirect("~/Error/404");
            }

            this.CardId = parsedCardId;
        }
    }
}