<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="MyOrder.aspx.cs" Inherits="JAwelsAndDiamonds.View.Customer.MyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GVOrders" runat="server" AutoGenerateColumns="False" OnRowCommand="GVOrders_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:dd MMM yyyy}" />
            <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
            <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="BtnViewDetails" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' />

                    <asp:Button ID="BtnConfirm" runat="server" Text="Confirm Package" CommandName="ConfirmPackage" CommandArgument='<%# Eval("TransactionID") %>' Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />

                    <asp:Button ID="BtnReject" runat="server" Text="Reject Package" CommandName="RejectPackage" CommandArgument='<%# Eval("TransactionID") %>' Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
