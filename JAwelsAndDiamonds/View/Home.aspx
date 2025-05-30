<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="JAwelsAndDiamonds.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>View Jewels</h1>

    <asp:GridView ID="GridView1" runat="server"
        DataKeyNames="JewelID"
        OnRowDeleting="GridView1_RowDeleting"
        OnRowEditing="GridView1_RowEditing" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="JewelID" SortExpression="JewelID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Jewel Price" SortExpression="JewelPrice" />

            <asp:HyperLinkField
                DataNavigateUrlFields="JewelID"
                DataNavigateUrlFormatString="Details.aspx?id={0}"
                Text="Details"
                HeaderText="Actions"></asp:HyperLinkField>
        </Columns>
    </asp:GridView>

</asp:Content>
