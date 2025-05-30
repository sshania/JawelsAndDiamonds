<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JAwelsAndDiamonds.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>Login</h1>
            </div>

            <div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                </div>

                <div>
                    <asp:CheckBox ID="RememberMeCheckBox" runat="server" />
                    <asp:Label ID="RememberLabel" runat="server" Text="Remember Me"></asp:Label>
                </div>

                <div>
                    <asp:Button ID="Login_Btn" runat="server" Text="Login" OnClick="Login_Btn_Click" />
                </div>

                <div>
                    <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
