<%@ Page Language="C#" AutoEventWireup="true" Title="Card details" MasterPageFile="~/Site.Master" CodeBehind="CardsDetails.aspx.cs" Inherits="AccountSystem.WebForms.Users.Admin.CardsDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Card information</h2>                
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ExpirationDate" CssClass="col-md-2 control-label">Expiration Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ExpirationDate" CssClass="form-control" TextMode="DateTime"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ExpirationDate"
                    CssClass="text-danger" ErrorMessage="The balance field is required." />
            </div>
            <asp:Label runat="server" AssociatedControlID="CardNumber" CssClass="col-md-2 control-label">Card Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CardNumber" CssClass="form-control" TextMode="DateTime"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CardNumber"
                    CssClass="text-danger" ErrorMessage="The balance field is required." />
            </div>
            Username: 
            <asp:Label runat="server" ID="LabelUserName"></asp:Label>
            <h3>Account Information</h3>
            Balance: 
            <asp:Label runat="server" ID="LabelBalance"></asp:Label>
            <br />Currency Type: 
            <asp:Label runat="server" ID="LabelCurrencyType"></asp:Label>
            <br />Account Status: 
            <asp:Label runat="server" ID="LabelAccountStatus"></asp:Label>
            <br />Card Status: 
            <asp:Label runat="server" ID="LabelCardStatus"></asp:Label>
            <br />Card Type: 
            <asp:Label runat="server" ID="LabelCardType"></asp:Label>
            <br />
            <asp:Button ID="ButtonDecline" Text="Decline" OnClick="Decline" runat="server" CssClass="btn btn-primary"></asp:Button>
            <asp:Button ID="ButtonApprove" Text="Approve" OnClick="Approve" runat="server" CssClass="btn btn-primary"></asp:Button>
        </div>
    </div>

</asp:Content>
