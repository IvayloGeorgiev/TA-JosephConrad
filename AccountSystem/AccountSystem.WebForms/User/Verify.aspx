<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Verify.aspx.cs" Inherits="AccountSystem.WebForms.User.Verify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Verification Documents</h2>
    </div>
    <asp:Panel ID="FormError" runat="server" Visible="false" CssClass="alert alert-dismissable alert-danger">
        <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
    </asp:Panel>
    <asp:Panel ID="FormSuccess" runat="server" Visible="false" CssClass="alert alert-dismissable alert-success">
        <asp:Label runat="server" ID="SuccessLabel" Text="Upload status: " />
    </asp:Panel>
    <span class="btn btn-success btn-file form-control">Choose file
        <asp:FileUpload ID="FileUploadControl" runat="server" />
    </span>
    <br />
    <br />
    <asp:Button runat="server" ID="UploadButton" Text="Upload File" OnClick="UploadButton_Click" CssClass="btn btn-success form-control" />
</asp:Content>
