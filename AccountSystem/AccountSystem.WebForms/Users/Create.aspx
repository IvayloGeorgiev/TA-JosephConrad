<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="AccountSystem.WebForms.Users.Create" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <p style="color:lightblue">
        <asp:Literal runat="server" ID="CreatedMessage" />
    </p>
    <asp:PlaceHolder runat="server" ID="createUser" Visible="false">
        <div class="form-horizontal">
            <h4>Create a new account</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="TextBoxUserName" CssClass="col-md-2 control-label">Username</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxUserName" CssClass="form-control"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxUserName"
                        CssClass="text-danger" ErrorMessage="The username field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="The email field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Phone Number</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxPhoneNumber" CssClass="form-control" TextMode="Number"/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPhoneNumber"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The phone number field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Select Role</asp:Label>
                <asp:DropDownList ID="DropDownListRoles" runat="server">
                    <asp:ListItem Text="Client" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Admin"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <h3>Adress Information</h3>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">City</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxCity" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCity"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The city field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Country</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxCountry" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCountry"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The country field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Postal Code</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxPostalCode" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPostalCode"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The postal code field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Street</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxStreet" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStreet"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The street field is required." />
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Create" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="noPermission" runat="server" Visible="false">
        <h2>You do not have permissions for this page</h2>
    </asp:PlaceHolder>
</asp:Content>
