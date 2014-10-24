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
        private AccountSystemData data = new AccountSystemData(new AccountSystemDbContext());
        private string adminRoleId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("/");
            }

            var userId = User.Identity.GetUserId();

            var data = new AccountSystemData(new AccountSystemDbContext());
            adminRoleId = data.Roles.All().FirstOrDefault(r => r.Name == "Admin").Id;
            var users = data.Users.All().Where(u => !(u.Roles.Any(r => r.RoleId == adminRoleId))).ToList();
            UsersRepeater.DataSource = users;
            UsersRepeater.DataBind();
        }

        protected void FilterUsers(object sender, EventArgs e)
        {
            var users = data.Users.All().Where(x => x.UserName.Contains(TextBoxFilter.Text)).ToList();
            UsersRepeater.DataSource = users;
            UsersRepeater.DataBind();
        }

        protected void FindUser(object sender, EventArgs e)
        {
            GetUser(DropDownListFindBy.SelectedItem.Text, TextBoxFindUser.Text);
        }

        private void GetUser(string findBy, string searchData)
        {
            if (findBy == "username")
            {
                var user = data.Users.All().Where(x => x.UserName == searchData).FirstOrDefault();
                Redirect(user);
            }
            else if (findBy == "email")
            {
                var user = data.Users.All().Where(x => x.Email.Contains(searchData)).FirstOrDefault();
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