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
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridViewCards" runat="server" AutoGenerateColumns="false"
                CssClass="table table-hover table-striped" GridLines="None"
                AllowSorting="true" AllowPaging="true" PageSize="5"
                ItemType="AccountSystem.Models.FileUploadData" DataKeyNames="Id"
                SelectMethod="GridViewCards_GetData">
                <Columns>
                    <asp:BoundField DataField="UploadDate" DataFormatString="{0:d}"
                        HeaderText="Upload Date" SortExpression="UploadDate" />
                    <asp:BoundField DataField="FileType"
                        HeaderText="File Type" SortExpression="FileType" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="DocumentDownload" runat="server" CssClass="btn btn-primary"
                                Text="Download" OnCommand="DocumentDownload_Command" CommandArgument="<%# Item.Id %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
