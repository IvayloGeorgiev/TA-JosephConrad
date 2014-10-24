<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountSystem.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Bank Account Management System</h1>
        <img style="width: 100%;" src="http://www.cr2.com/assets/images/banner-inner-internet.png" />
    </div>

    <table class="table table-striped table-hover ">
        <thead>
            <tr>
                <th>Registered users</th>
                <th>Bank Accounts</th>
                <th>Cards</th>
                <th>Transactions</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lbUsersCount" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbAccountsCount" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbCardsCount" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbTransactionsCount" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
