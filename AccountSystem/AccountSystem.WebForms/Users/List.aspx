<%@ Page Title="Your profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="AccountSystem.WebForms.Users.List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    

    <div class="row">
        <h2>Users</h2>
        <asp:Repeater ID="UsersRepeater" runat="server"            
            ItemType="AccountSystem.Models.ApplicationUser">
            <HeaderTemplate>
                <table id="usersTable" class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th class="col-md-6">Id</th>
                            <th class="col-md-6">Username</th>                            
                        </tr>
                    </thead>                                    
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <a href="~/Users/Details?id=<%#: DataBinder.Eval(Container.DataItem, "Id") %>"><%#: DataBinder.Eval(Container.DataItem, "Id") %></a>
                    </td>
                    <td><%#: DataBinder.Eval(Container.DataItem, "Username") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

