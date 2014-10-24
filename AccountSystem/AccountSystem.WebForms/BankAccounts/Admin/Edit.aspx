<%@ Page Language="C#" Title="Edit bank account" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="AccountSystem.WebForms.BankAccounts.Admin.Edit" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new bank account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="BalanceField" CssClass="col-md-2 control-label">Balance</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="BalanceField" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BalanceField"
                    CssClass="text-danger" ErrorMessage="The balance field is required." />
                <asp:CustomValidator runat="server" ControlToValidate="BalanceField"
                    CssClass="text-danger" ErrorMessage="The balance field should be a positive decimal number." 
                    OnServerValidate="DecimalValidator_ServerValidate"/>
                <asp:CustomValidator runat="server" ControlToValidate="BalanceField"
                    CssClass="text-danger" ErrorMessage="The balance field cannot be less then the current balance." 
                    OnServerValidate="BalanceValidator_ServerValidate"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AccountStatusField" CssClass="col-md-2 control-label">Account status</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="AccountStatusField" runat="server"></asp:DropDownList>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountStatusField"
                    CssClass="text-danger" ErrorMessage="The currency type field is required." />
            </div>
        </div>        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="EditAccount_Click" Text="Edit account" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
