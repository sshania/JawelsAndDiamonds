<%@ Page Title="" Language="C#" MasterPageFile="~/View/Site.Master" AutoEventWireup="true" CodeBehind="AddJewel.aspx.cs" Inherits="JAwelsAndDiamonds.View.Admin.AddJewel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div>
           <div>
               <h1>Add Jewel</h1>
           </div>

           <div>
               <asp:Label ID="LabelJewelName" runat="server" Text="Jewel Name"></asp:Label>
               <asp:TextBox ID="JewelName" runat="server"></asp:TextBox>
           </div>

           <div>
               <asp:Label ID="LabelCategory" runat="server" Text="Category"></asp:Label>
               <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
           </div>

           <div>
               <asp:Label ID="LabelBrand" runat="server" Text="Brand"></asp:Label>
               <asp:DropDownList ID="ddlBrand" runat="server"></asp:DropDownList>
           </div>

           <div>
               <asp:Label ID="LabelPrice" runat="server" Text="Price"></asp:Label>
               <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
           </div>

           <div>
               <asp:Label ID="LabelYear" runat="server" Text="Release Year"></asp:Label>
               <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
           </div>

           <div>
               <asp:Button ID="btnAdd" runat="server" Text="Add Jewel" OnClick="btnAdd_Click" />
               <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
           </div>

           <div>
               <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" />
           </div>
       </div>
</asp:Content>
