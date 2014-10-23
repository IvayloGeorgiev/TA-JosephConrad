<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Create.aspx.cs" Inherits="AccountSystem.WebForms.BankAccounts.Admin.Create" %>

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
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CurTypeList" CssClass="col-md-2 control-label">Currency Type</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="CurTypeList" runat="server"></asp:DropDownList>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurTypeList"
                    CssClass="text-danger" ErrorMessage="The currency type field is required." />
            </div>
        </div>        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateAccount_Click" Text="Create account" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>


