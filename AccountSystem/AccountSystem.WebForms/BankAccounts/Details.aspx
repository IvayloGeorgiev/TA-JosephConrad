<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="AccountSystem.WebForms.BankAccounts.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome <%: Context.User.Identity.GetUserName() %></h1>
    </div>

    <div class="row">
        <h2>Your accounts</h2>
        <% if (HttpContext.Current.User.IsInRole("Admin")) { %>
            <a class="btn btn-primary" href="/BankAccounts/Create">Create account</a>
        <% } %>
        <asp:Repeater ID="AccountsRepeater" runat="server">
            <HeaderTemplate>
                <table id="accountTable" class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th class="col-md-8">IBAN</th>
                            <th class="col-md-3">Balance</th>
                            <th class="col-md-1">Currency</th>
                        </tr>
                    </thead>                                    
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <a href="~/BankAccounts/Details?id=<%#: DataBinder.Eval(Container.DataItem, "Iban") %>"><%#: DataBinder.Eval(Container.DataItem, "Iban") %></a>
                    </td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "Balance") %></td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "CurrencyType") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

