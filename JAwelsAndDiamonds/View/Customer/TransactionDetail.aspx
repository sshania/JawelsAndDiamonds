<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="JAwelsAndDiamonds.View.Customer.TransactionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <strong>Transaction ID:</strong>
        <asp:Label ID="TransactionId" runat="server" Text=""></asp:Label>
    </div>
    <asp:GridView ID="GVTransactionDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" GridLines="None">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>

    <%--<div ">
        <strong>Jewel Name:</strong>
        <asp:Label ID="JewelName" runat="server" Text=""></asp:Label>
    </div>

    <div >
        <strong>Quantity:</strong>
        <asp:Label ID="Quantity" runat="server" Text=""></asp:Label>
    </div>--%>

    <div >
        <asp:Button ID="btnBack" runat="server" Text="Back to My Orders" OnClick="btnBack_Click" />
    </div>

</asp:Content>
