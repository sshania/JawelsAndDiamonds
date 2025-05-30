<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="JAwelsAndDiamonds.View.Customer.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="CartGridView" runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="JewelID"
        OnRowCommand="CartGridView_RowCommand"
        OnRowDataBound="CartGridView_RowDataBound">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="Jewel Id" SortExpression="JewelID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" SortExpression="JewelName" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" SortExpression="JewelPrice" />
            <asp:BoundField DataField="JewelBrand" HeaderText="Brand" SortExpression="JewelBrand" />

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="TxtQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                    <asp:Button ID="BtnRemove" runat="server" Text="Remove" OnClick="BtnRemove_Click" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <asp:Label ID="LblTotal" runat="server" Text="Total: $0.00"></asp:Label><br />
    <asp:DropDownList ID="DDL_Payment" runat="server">
        <asp:ListItem Text="-- Select Payment Method --" Value="" />
        <asp:ListItem Text="Visa" Value="Visa" />
        <asp:ListItem Text="MasterCard" Value="MasterCard" />
    </asp:DropDownList><br />
    <br />

    <asp:Button ID="BtnClearCart" runat="server" Text="Clear Cart" OnClick="BtnClearCart_Click" />
    <asp:Button ID="BtnCheckout" runat="server" Text="Proceed to Checkout" OnClick="BtnCheckout_Click" />

    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>


</asp:Content>
