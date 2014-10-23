using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using AccountSystem.Data;


namespace AccountSystem.WebForms.Users
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("/");
            }
            
            var userId = User.Identity.GetUserId();

            var data = new AccountSystemData(new AccountSystemDbContext());

            var users = data.Users.All().ToList();           
            UsersRepeater.DataSource = users;
            UsersRepeater.DataBind();
        }
    }
}