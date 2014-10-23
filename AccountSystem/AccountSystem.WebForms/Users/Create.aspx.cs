using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using AccountSystem.WebForms.Models;
using AccountSystem.Models;
using System.Web.Security;

namespace AccountSystem.WebForms.Users
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.IsInRole("Admin"))
            {
                createUser.Visible = true;
            }
            else
            {
                noPermission.Visible = true;
                Response.Redirect("../Account/Login");
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            Address adress = new Address();
            adress.City = TextBoxCity.Text;
            adress.Country = TextBoxCountry.Text;
            adress.PostalCode = TextBoxPostalCode.Text;
            adress.Street = TextBoxStreet.Text;
            string phoneNumber = TextBoxPhoneNumber.Text;
            string role = DropDownListRoles.SelectedItem.Text;

            var user = new ApplicationUser() { UserName = TextBoxUserName.Text, Email = Email.Text, Address = adress, PhoneNumber = phoneNumber };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                if (role == "Admin")
                {
                    manager.AddToRole(user.Id, role);
                    CreatedMessage.Text = "Admin Created.";
                }
                else if (role == "Client")
                {
                    manager.AddToRole(user.Id, role);
                    CreatedMessage.Text = "Client Created.";
                }
                else
                {
                    CreatedMessage.Text = "User Created.";
                }
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}