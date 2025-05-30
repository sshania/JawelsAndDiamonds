<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="JAwelsAndDiamonds.View.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Jewel Details</h2>
    <div>
        <div>
            <strong>Jewel Name:</strong> <asp:Label ID="lblJewelName" runat="server" Text="" />
        </div>
        <div>
            <strong>Category:</strong> <asp:Label ID="lblJewelCategory" runat="server" Text="" />
        </div>
        <div>
            <strong>Brand:</strong> <asp:Label ID="lblJewelBrand" runat="server" Text="" />
        </div>
        <div>
            <strong>Brand Country Origin:</strong> <asp:Label ID="lblCountryOrigin" runat="server" Text="" />
        </div>
        <div>
            <strong>Brand Class:</strong> <asp:Label ID="lblClass" runat="server" Text=""/>
        </div>
        <div>
            <strong>Price:</strong> <asp:Label ID="lblPrice" runat="server" Text=""/>
        </div>
        <div>
            <strong>Release Year:</strong> <asp:Label ID="lblReleaseYear" runat="server" Text=""/>
        </div>

        <asp:Panel ID="addToCartBtn" runat="server" Visible="false">
            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" OnClick="btnAddToCart_Click" />
        </asp:Panel>

        <asp:Panel ID="adminButtons" runat="server" Visible="false">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </asp:Panel>
    </div>
</asp:Content>
