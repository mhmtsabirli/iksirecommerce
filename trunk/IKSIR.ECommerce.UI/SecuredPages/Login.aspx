<%@ Page Title="" Language="C#" MasterPageFile="~/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Üye Girişi</h2>
    <p>
        <i>Lütfen üye girişi yapınız</i>
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
                    <asp:RegularExpressionValidator runat="server" ID="regex1" ControlToValidate="txtEmail"
                        ErrorMessage="Geçersiz Eposta adresi" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                        ValidationGroup="vgLoginControlForm" SetFocusOnError="true">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="48" class="sidemenu_kullanici_adi_login"
                        title="E-posta Adresiniz"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Şifreniz
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtPassword"
                        SetFocusOnError="true" ErrorMessage="Şifrenizi girmelisiniz" ValidationGroup="vgLoginControlForm">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPassword" MaxLength="38" TextMode="Password" class="sidemenu_sifre_login"
                        title="Şifreniz"></asp:TextBox>
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
