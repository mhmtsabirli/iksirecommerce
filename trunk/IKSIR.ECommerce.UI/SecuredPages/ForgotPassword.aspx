<%@ Page Title="" Language="C#" MasterPageFile="~/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                :
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtEmail"
                    ErrorMessage="Kullanıcı adınızı girmelisiniz" SetFocusOnError="true" ValidationGroup="vgLoginControlForm">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" MaxLength="48" class="sidemenu_kullanici_adi_login"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="color: Red !important;">
                <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="vgLoginControlForm"
                    CssClass="ValidationSummaryClass" />
                <asp:Label runat="server" ID="Label1" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Label runat="server" ID="lblAlert"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" ValidationGroup="vgLoginControlForm"
                    class="footer_module_submit" />
            </td>
        </tr>
    </table>
</asp:Content>
