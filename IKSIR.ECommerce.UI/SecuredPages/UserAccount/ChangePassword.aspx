<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.UserAccount.ChangePassword" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main" style="padding-left: 10px; margin-left: 200px">
        <h2>
            Hesabım
        </h2>
        <p>
            Kullanıcı hesap biglileri görüntüleme, düzenleme.
        </p>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="left" colspan="2">
                    <div id="divAlert" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="tabs">
                        <ul>
                            <li><a href="UserInfos.aspx"><span>Üye Bilgilerim</span></a></li>
                            <li><a href="Addresses.aspx"><span>Adreslerim</span></a></li>
                            <li><a href="Orders.aspx"><span>Siparişlerim</span></a></li>
                            <li><a href="FavoriteProducts.aspx"><span>Favori Ürünlerim</span></a></li>
                            <li><a href="ChangePassword.aspx" style="background-position: 0% -42px;"><span style="background-position: 0% -42px;">
                                Şifre Değiştir</span></a></li>
                        </ul>
                    </div>
                    <table>
                        <tr>
                            <td colspan="5">
                                <strong>Şifre Değiştir</strong> (Şifrenizi değiştirin)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Eski Şifre
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                *
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtExPassword"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Yeni Şifre
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                *
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtChangePassword_Password"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Yeni Şifre tekrar
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                *
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtChangePassword_PasswordAgain"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <asp:Label runat="server" ID="lblChangePassword_Alert"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <asp:Button runat="server" ID="btnChangePassword" Text="Şifremi Değiştir" OnClick="btnChangePassword_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
