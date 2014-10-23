<%@ Page Title="Your profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="AccountSystem.WebForms.Users.List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    

    <div class="row">
        <h2>Users</h2>
        <div>
            Find user by  
            <asp:DropDownList ID="DropDownListFindBy" runat="server">
                    <asp:ListItem Text="username" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="email"></asp:ListItem>
                </asp:DropDownList>
            <asp:TextBox ID="TextBoxFindByUserName" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonFindByUserName" Text="Find" runat="server" OnClick="FindUser" />
        </div>
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
                        <a href="/Users/Admin/UserDetails?id=<%#: DataBinder.Eval(Container.DataItem, "Id") %>"><%#: DataBinder.Eval(Container.DataItem, "Id") %></a>
                    </t>
                    <td><%#: DataBinder.Eval(Container.DataItem, "Username") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

