<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TransactionHistory.aspx.cs" Inherits="AccountSystem.WebForms.BankAccounts.TransactionHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome <%: Context.User.Identity.GetUserName() %></h1>
    </div>

    <div class="row">
        <h2>Your transactions</h2>        

        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="GridViewTransactions" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover table-striped" GridLines="None" 
                    AllowSorting="true" AllowPaging="true" PageSize="20"
                    ItemType="AccountSystem.Models.Transaction" DataKeyNames="Id"
                    SelectMethod="GridViewTransactions_GetData">
                    <Columns>
                        <asp:BoundField DataField="TimeOfTransaction" DataFormatString = "{0:G}"
                            HeaderText="Date" SortExpression="TimeOfTransaction"/>                        
                        <asp:BoundField DataField="Reason"
                            HeaderText="Reason" SortExpression="Reason" />                        
                        <asp:BoundField DataField="Amount"
                            HeaderText="Amount" SortExpression="Amount" />         
                        <asp:BoundField DataField="TargetIban"               
                            HeaderText="Target" SortExpression="TargetIban" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
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
