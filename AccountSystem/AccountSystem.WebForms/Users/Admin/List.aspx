<%@ Page Title="Your profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="AccountSystem.WebForms.Users.List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="jumbotron">
            <h2>Users Administration</h2>
            <div class="row">
                <div class="col-md-4">
                    <asp:HyperLink runat="server" NavigateUrl="~/Users/Create" CssClass="btn btn-primary">Create User</asp:HyperLink>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                Find user by  
            <asp:DropDownList ID="DropDownListFindBy" runat="server">
                <asp:ListItem Text="username" Selected="True"></asp:ListItem>
                <asp:ListItem Text="email"></asp:ListItem>
            </asp:DropDownList>
                <asp:TextBox ID="TextBoxFindUser" runat="server" CssClass="input-sm"></asp:TextBox>
                <asp:Button ID="ButtonFindUser" Text="Find" runat="server" CssClass="btn btn-primary" OnClick="FindUser" />
            </div>
            <div class="col-md-6">
                Filter users by username 
                <asp:TextBox ID="TextBoxFilter" runat="server" CssClass="input-sm"></asp:TextBox>
                <asp:Button ID="ButtonFilterUsers" Text="Filter" runat="server" CssClass="btn btn-primary" OnClick="FilterUsers" />
            </div>
        </div>
        <asp:Repeater ID="UsersRepeater" runat="server"
            ItemType="AccountSystem.Models.ApplicationUser">
            <HeaderTemplate>
                <table id="usersTable" class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th class="col-md-6">Id</th>
                            <th class="col-md-6">Username</th>
                            <th class="col-md-6">Email</th>
                        </tr>
                    </thead>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <a href="/Users/Admin/UserDetails?id=<%#: DataBinder.Eval(Container.DataItem, "Id") %>"><%#: DataBinder.Eval(Container.DataItem, "Id") %></a>
                    </t>
                    <td><%#: DataBinder.Eval(Container.DataItem, "Username") %></td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "Email") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

