﻿namespace AccountSystem.WebForms.BankAccounts.Admin
{
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

    public partial class Create : System.Web.UI.Page
    {
        protected string userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("/");
            }

            userId = Request.QueryString["id"];
            if (userId == null)
            {
                Response.Redirect("/"); // TODO - error message.
            }     

            var values = Enum.GetValues(typeof(CurrencyType));

            CurTypeList.DataSource = values;
            CurTypeList.DataBind();
            CurTypeList.SelectedIndex = 0;            
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) 
            { 
                var curType = (CurrencyType)Enum.Parse(typeof(CurrencyType), CurTypeList.SelectedValue, true);                   

                var newAccount = new BankAccount() { Balance = decimal.Parse(BalanceField.Text), CurrencyType = curType, OwnerId = userId, Status = AccountStatus.Active };
                var data = new AccountSystemData(new AccountSystemDbContext());
                data.Accounts.Add(newAccount);
                data.SaveChanges();

                Response.Redirect("/Users/Admin/UserDetails?id=" + userId);
            }
        }

        protected void DecimalValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                decimal.Parse(args.Value);
                args.IsValid = true;
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }
    }
}