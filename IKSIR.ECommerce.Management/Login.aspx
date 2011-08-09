<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IKSIR.ECommerce.Management.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kullanıcı Girişi</title>
    <style type="text/css">
        .style3
        {
            width: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="left: 200px;">
        <table>
            <tr>
                <td>
                </td>
                <td style="height: 50%;">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 30%;">
                    <img src="http://www.eviniyenileturkiye.com/images/logolar/idevit.jpg" style="border: none;" />
                </td>
                <td style="width: 40%;">
                    <table>
                        <tr>
                            <td colspan="4" style="width: 500px;">
                                Kullanıcı Girişi
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Kullanıcı Adı
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" MaxLength="100" ID="txtUserName"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Şifre
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" MaxLength="100" TextMode="Password" ID="txtPass"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnOk" runat="server" Text="Giriş" OnClick="btnOk_Click" Width="136px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="dvalert" runat="server" visible="false">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 30%;">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="height: 50%;">
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
