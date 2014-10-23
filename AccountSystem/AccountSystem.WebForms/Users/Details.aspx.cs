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

namespace AccountSystem.WebForms.Users
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login");
            }
           
            var userId = User.Identity.GetUserId();            

            var data = new AccountSystemData(new AccountSystemDbContext());

            var accounts = data.Accounts.All().Where(x => x.OwnerId == userId).ToList();

            AccountsRepeater.DataSource = accounts;
            AccountsRepeater.DataBind();
        }
    }
}