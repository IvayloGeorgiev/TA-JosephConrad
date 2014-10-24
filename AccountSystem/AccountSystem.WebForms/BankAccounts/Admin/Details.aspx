<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="AccountSystem.WebForms.BankAccounts.Admin.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2><%: username.ToString() %>'s account</h2>                
        <br />
    </div>
    <div class="row">
        <div class="col-md-6">
            <h2>Account Details:</h2>
            <div>
                <asp:DetailsView ID="AccountDetailsView" runat="server" AutoGenerateRows="true">
                </asp:DetailsView>
            </div>
            <div class="row">
                <div class="col-md-3">Currency:</div>
                <div class="col-md-9"><asp:Literal ID="LiteralCurrency" runat="server"></asp:Literal></div>
            </div>
            <div class="row">
                <div class="col-md-3">Balance:</div>
                <div class="col-md-9"><asp:Literal ID="LiteralBalance" runat="server"></asp:Literal></div>
            </div>
            <div class="row">
                <div class="col-md-3">Owner:</div>
                <div class="col-md-9"><asp:Literal ID="LiteralOwner" runat="server"></asp:Literal></div>
            </div>
            <div class="row">
                <div class="col-md-3">Status:</div>
                <div class="col-md-9"><asp:Label ID="LabelStatus" runat="server"></asp:Label></div>
            </div>
        </div>
        <div class="col-md-6">            
            <div class="row">
            <asp:LinkButton ID="TransactionHistory" runat="server" CssClass="btn btn-primary"
                                Text="Transaction History" OnCommand="TransactionHistory_Command" />     
            </div>   
            <br />
            <div class="row">
            <asp:LinkButton ID="EditAccount" runat="server" CssClass="btn btn-primary"
                                Text="Edit account" OnCommand="EditAccount_Command" />  
            </div>      
            <br />
        </div>
    </div>

</asp:Content>

