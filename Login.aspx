<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UserManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <script type="text/javascript">
        function ValidateInput() {
            var Name, gender, errMsg;
            Name = document.getElementById("txtUserId").value;
            gender = document.getElementById("txtPassword").value;
            errMsg = document.getElementById("lblMsg").value;

            if (Name == '') {
                lblMsg.innerHTML = "Please Enter Username";
                return false;
            }
            if (gender == '') {
                lblMsg.innerHTML = "Please Enter Password";
                return false;
            }
            lblMsg.innerHTML = '';
            return true;
        }
    </script>
</head>
<body>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbg">
        <div style="padding: 5px;">
            <a class="navbar-brand" runat="server" href="~/">
                <img src="veslogo.png" height="45" alt="VES User Mangement" />
            </a>
        </div>

    </nav>
    <div>
        <form id="form2" runat="server">
            <div style="width: 30%; margin: 4% auto; border: 1px solid #D6D6D6; padding: 10px;">
                <%--<div>
                    Please enter details
                </div>--%>
                <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
                <br />
                <table cellpadding="3" cellspacing="2">
                    <tr>
                        <td style="width: 40%;">Enter Username
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Enter Password
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>                    
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" OnClientClick="return ValidateInput()" />
                        </td>
                    </tr>
                </table>                
            </div>
        </form>
    </div>
</body>
</html>
