<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserDetails.aspx.cs" Inherits="AccountSystem.WebForms.Users.Admin.UserDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2><%: username.ToString() %>'s accounts</h2>                
        <br />
        <div class="row">
            <a class="btn btn-primary" href="~/BankAccounts/Create">Create account</a>        
        </div>
        <br />
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
                        <a href="~/BankAccounts/Admin/Details?id=<%#: DataBinder.Eval(Container.DataItem, "Iban") %>"><%#: DataBinder.Eval(Container.DataItem, "Iban") %></a>
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
