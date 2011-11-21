<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left: 230px;">
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
                        &nbsp;:&nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" MaxLength="48" CssClass="sidemenu_kullanici_adi_login"
                            title="E-posta Adresiniz"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Şifreniz
                    </td>
                    <td>
                        &nbsp;:&nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" MaxLength="38" TextMode="Password" CssClass="sidemenu_sifre_login"
                            title="Şifreniz"></asp:TextBox>
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
                        <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" CssClass="footer_module_submit" />
                        <a href="Register.aspx">Yeni Üyelik</a>
                        &nbsp;&nbsp;
                        <a href="ForgotPassword.aspx">Şifremi Unuttum</a>
                    </td>
                </tr>
            </table>
    </div>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%=txtEmail.ClientID%>').keypress(function (event) {
                if (event.which == 13) {
                    $('#<%=btnLogin.ClientID%>').trigger("click");
                    __doPostBack('', '');
                }
            });

            $("#txtPassword").keypress(function (event) {
                if (event.which == 13) {
                    $('#<%=btnLogin.ClientID%>').trigger("click");
                }
            });
        });
    </script>
</asp:Content>
