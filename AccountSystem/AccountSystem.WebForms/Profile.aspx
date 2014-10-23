<%@ Page Title="Your profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AccountSystem.WebForms.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome <%: Context.User.Identity.GetUserName() %></h1>
    </div>

    <div class="row">
        <h2>Your accounts</h2>
        <asp:Repeater ID="AccountsRepeater" runat="server"            
            ItemType="AccountSystem.Models.Account">
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
                        <a href="~/Accounts/Details?id=<%#:  %>"><%#: DataBinder.Eval(Container.DataItem, "Iban") %></a>
                        <%#: DataBinder.Eval(Container.DataItem, "Balance") %>
                        <%#: DataBinder.Eval(Container.DataItem, "CurrencyType") %>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

