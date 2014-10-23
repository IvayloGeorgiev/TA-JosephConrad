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

        protected void FindUser(object sender, EventArgs e)
        {
            GetUser(DropDownListFindBy.SelectedItem.Text, TextBoxFindByUserName.Text);
        }

        private void GetUser(string findBy, string searchData)
        {
            var data = new AccountSystemData(new AccountSystemDbContext());

            if (findBy == "username")
            {
                var user = data.Users.All().Where(x => x.UserName == searchData).FirstOrDefault();
                Redirect(user);
            }
            else if (findBy == "email")
            {
                var user = data.Users.All().Where(x => x.Email == searchData).FirstOrDefault();
                Redirect(user);
            }
        }

        private void Redirect(AccountSystem.Models.ApplicationUser user)
        {
            if (user != null)
            {
                Response.Redirect("UserDetails?id=" + user.Id);
            }
            else
            {
            }
        }
    }
}