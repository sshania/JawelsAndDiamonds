<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="JAwelsAndDiamonds.View.Admin.HandleOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Handle Orders</h2>
    <div>
        <div>
            <asp:GridView ID="TransactionGridView" runat="server" AutoGenerateColumns="False" 
            OnRowDataBound="TransactionGridView_RowDataBound"
            OnRowCommand="TransactionGridView_RowCommand"
            DataKeyNames="TransactionId">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction Id" />
                <asp:BoundField DataField="UserId" HeaderText="User Id" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="Btn_Confirm" runat="server" Text="Confirm Payment" CssClass="action-btn"
                            CommandName="Confirm" CommandArgument="<%# Container.DataItemIndex %>" Visible="false" />
                        
                        <asp:Button ID="Btn_Ship" runat="server" Text="Ship Package" CssClass="action-btn"
                            CommandName="Ship" CommandArgument="<%# Container.DataItemIndex %>" Visible="false" />
                        
                        <asp:Label ID="Lbl_Arrived" runat="server" Text="Waiting user confirmation..." Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
</asp:Content>
