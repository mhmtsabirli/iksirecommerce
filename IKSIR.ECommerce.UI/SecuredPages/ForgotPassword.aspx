<%@ Page Title="" Language="C#" MasterPageFile="~/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 230px;">
        <h2>
            Şifremi Unuttum</h2>
        <p>
            <i>Şifrenizi unuttuysanız mail adresinizi girerek şifrenizin mail adresine gönderilmesini
                sağlayabilirsiniz. </i>
        </p>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    Kullanıcı Adınız (Emailiniz)
                </td>
                <td>
                    &nbsp;:&nbsp;
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="48" class="sidemenu_kullanici_adi_login"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="color: Red !important;">
                    <asp:Label runat="server" ID="Label1" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <div runat="server" id="divAlert">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" class="footer_module_submit" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
