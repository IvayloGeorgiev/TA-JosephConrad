<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="AccountSystem.WebForms.User.AddAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="jumbotron">
                <h2>New Account Form</h2>
            </div>
        </div>
        <div class="row">
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />
            </p>
            <p style="color: lightblue">
                <asp:Literal runat="server" ID="CreatedMessage" />
            </p>

            <div class="form-group">
                <label for="select" class="col-lg-2 control-label">Choose Account Type</label>
                <div class="col-lg-10">
                    <asp:DropDownList ID="ListBoxCurrencyTypes" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ListBoxCurrencyTypes"
                        CssClass="text-danger" ErrorMessage="Currency type is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2">
                    <asp:HyperLink CssClass="btn btn-default" runat="server" NavigateUrl="~/Users/Details">Cancel</asp:HyperLink>
                    <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="AddNewAccount" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
