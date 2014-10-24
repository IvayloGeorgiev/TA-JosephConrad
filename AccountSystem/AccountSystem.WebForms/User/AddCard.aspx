<%@ Page Title="Add New Bank Card" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCard.aspx.cs" Inherits="AccountSystem.WebForms.User.AddCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Add Card</legend>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <p style="color: lightblue">
            <asp:Literal runat="server" ID="CreatedMessage" />
        </p>
        <div class="form-group">
            <label for="inputPin" class="col-lg-2 control-label">Pin code</label>
            <div class="col-lg-10">
                <asp:TextBox ID="tbPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPassword"
                    CssClass="text-danger" ErrorMessage="Password is required." />
            </div>
        </div>
        <div class="form-group">
            <label for="select" class="col-lg-2 control-label">Card Types</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="ListBoxCardTypes" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ListBoxCardTypes"
                    CssClass="text-danger" ErrorMessage="Card type is required." />
            </div>
        </div>
        <div class="form-group">
            <label for="select" class="col-lg-2 control-label">Available Accounts</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="ListBoxBankAccounts" runat="server" DataTextField="IBAN" DataValueField="Id" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ListBoxBankAccounts"
                    CssClass="text-danger" ErrorMessage="Bank account is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <asp:HyperLink CssClass="btn btn-default" runat="server" NavigateUrl="~/User/Cards">Cancel</asp:HyperLink>
                <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="AddNewCard" />
            </div>
        </div>
    </fieldset>
</asp:Content>
