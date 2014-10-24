<%@ Page Language="C#" Title="Transfer funds" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Transfer.aspx.cs" Inherits="AccountSystem.WebForms.BankAccounts.Transfer" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new bank account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AmountField" CssClass="col-md-2 control-label">Amount</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AmountField" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AmountField"
                    CssClass="text-danger" ErrorMessage="The amount field is required." />
                <asp:CustomValidator runat="server" ControlToValidate="AmountField"
                    CssClass="text-danger" ErrorMessage="The amount field should be a valid decimal number" 
                    OnServerValidate="DecimalValidator_ServerValidate"/>
                <asp:CustomValidator runat="server" ControlToValidate="AmountField"
                    CssClass="text-danger" ErrorMessage="The amount field should not exceed the available account funds" 
                    OnServerValidate="AccountBalanceCheck_ServerValidate"/>
            </div>
        </div>               
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TargetIBANField" CssClass="col-md-2 control-label">Target IBAN</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TargetIBANField" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TargetIBANField"
                    CssClass="text-danger" ErrorMessage="The target iban field is required." />
                <asp:CustomValidator runat="server" ControlToValidate="TargetIBANField" 
                    CssClass="text-danger" ErrorMessage="Target Iban had improper length" 
                    OnServerValidate="IbanLength_ServerValidate" />
            </div>
        </div>               
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ReasonField" CssClass="col-md-2 control-label">Reason</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ReasonField" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ReasonField"
                    CssClass="text-danger" ErrorMessage="The reason field is required." />                
            </div>
        </div>               
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="TransferFunds_Click" Text="Transfer funds" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
