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

namespace AccountSystem.WebForms.BankAccounts.Admin
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                   
            var values = from CurrencyType enumValue in Enum.GetValues(typeof(CurrencyType))
                            select new { ID = Convert.ToInt32(enumValue), Name = enumValue.ToString() };            
            
            CurTypeList.DataSource = values;
            CurTypeList.DataBind();
            CurTypeList.SelectedIndex = 1;            
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {

        }
    }
}