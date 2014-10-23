<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/User/Cards.aspx.cs" Inherits="AccountSystem.WebForms.User.Cards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cards Manager</h1>
    <div class="row">
        <div class="col-md-4">
            <asp:HyperLink runat="server" NavigateUrl="~/User/Card/Add" CssClass="btn btn-primary">Request New Card</asp:HyperLink>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridViewCards" runat="server" AutoGenerateColumns="false"
                CssClass="table table-hover table-striped" GridLines="None"
                AllowSorting="true" AllowPaging="true" PageSize="5"
                ItemType="AccountSystem.Models.Card" DataKeyNames="Id"
                SelectMethod="GridViewCards_GetData">
                <Columns>
                    <asp:BoundField DataField="CardNumber"
                        HeaderText="Card Number" SortExpression="CardNumber" />
                    <asp:BoundField DataField="CardType"
                        HeaderText="Type" SortExpression="CardType" />
                    <asp:BoundField DataField="ExpirationDate" DataFormatString="{0:d}"
                        HeaderText="Expiration Date" SortExpression="ExpirationDate" />
                    <asp:BoundField DataField="CardStatus"
                        HeaderText="Card Status" SortExpression="CardStatus" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="CardDetails" runat="server" CssClass="btn btn-primary"
                                Text="Details" OnCommand="CardDetails_Command" CommandArgument="<%# Item.Id %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
