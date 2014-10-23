<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="AccountSystem.WebForms.BankAccounts.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome <%: Context.User.Identity.GetUserName() %></h1>
    </div>

    <div class="row">
        <h2>Account Details:</h2>
        <div>
            <asp:DetailsView ID="AccountDetailsView" runat="server" AutoGenerateRows="true">
            </asp:DetailsView>
        </div>
        <div>
            Currency:
            <asp:Label ID="LabelCurrency" runat="server"></asp:Label>
        </div>
        <div>
            Balance:
            <asp:Label ID="LabelBalance" runat="server"></asp:Label>
        </div>
        <div>
            Owner:
            <asp:Label ID="LabelOwner" runat="server"></asp:Label>
        </div>
        <a href="/">View Cards</a>
        <br />
        <a href="/">View Transactions</a>
    </div>

</asp:Content>

