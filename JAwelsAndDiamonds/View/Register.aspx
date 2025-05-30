<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="JAwelsAndDiamonds.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>Register</h1>
            </div>

            <div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Label3" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="Username" runat="server"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label><br />
                    <asp:RadioButtonList ID="GenderList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div>
                    <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>
                    <asp:TextBox ID="TxtDOB" runat="server" TextMode="Date"></asp:TextBox>
                </div>

                <div>
                    <asp:Button ID="Register_Btn" runat="server" Text="Register" OnClick="Register_Btn_Click" />
                </div>

                <div>
                    <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
