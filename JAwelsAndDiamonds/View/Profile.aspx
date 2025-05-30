<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" 
    Inherits="JAwelsAndDiamonds.View.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>User Profile</h2>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <br />

    <asp:Panel ID="pnlProfileInfo" runat="server">
        <strong>Username:</strong>
        <asp:Label ID="lblUsername" runat="server" /><br />
        <strong>Email:</strong>
        <asp:Label ID="lblEmail" runat="server" /><br />
    </asp:Panel>

    <hr />

    <h3>Change Password</h3>

    <asp:Label ID="lblChangePasswordMessage" runat="server" ForeColor="Red"></asp:Label><br />

    <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label><br />
    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" /><br />
    <br />

    <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label><br />
    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" /><br />
    <br />

    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label><br />
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /><br />
    <br />

    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />


</asp:Content>
