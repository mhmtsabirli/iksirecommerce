<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Register"
    UICulture="tr" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Üye Kayıt Formu
    </h2>
    <p>
        <i>* ile belirtilen alanların doldurulması zorunludur.</i>
    </p>
    <table>
        <tr>
            <td>
                Ad
            </td>
            <td>
                :
            </td>
            <td>
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFirstName" Enabled="false"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Soyad
            </td>
            <td>
                :
            </td>
            <td>
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLastName" Enabled="false"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                E-posta
            </td>
            <td>
                :
            </td>
            <td>
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" Enabled="false"></asp:TextBox>
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
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" Enabled="false"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Şifre tekrar
            </td>
            <td>
                :
            </td>
            <td>
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPasswordAgain" TextMode="Password" Enabled="false"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Doğum Tarihi
            </td>
            <td>
                :
            </td>
            <td>
                *
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlBirthDateDay" Enabled="false">
                </asp:DropDownList>
                /
                <asp:DropDownList runat="server" ID="ddlBirthDateMonth" Enabled="false">
                </asp:DropDownList>
                /
                <asp:DropDownList runat="server" ID="ddlBirthDateYear" Enabled="false">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                E Bülten Aboneliği
            </td>
            <td>
                :
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:CheckBox runat="server" ID="cbxEBulten" Text="E bülten aboneliği istiyorum" />
            </td>
            <td>
            </td>
        </tr>
        <%--<tr>
            <td valign="top">
                Güvenlik Kodu
            </td>
            <td valign="top">
                :
            </td>
            <td valign="top">
                *
            </td>
            <td valign="top">
                <asp:Image ID="imgSecurity" CssClass="CaptchaImage" ImageUrl="CaptchaCode.aspx" runat="server"
                    AlternateText="Güvenlik Kodu" />
                <asp:LinkButton runat="server" ID="lbtnChangeCode" Text="Değiştir" 
                    onclick="lbtnChangeCode_Click" Visible="false"></asp:LinkButton>
                <br />
                <asp:TextBox runat="server" CssClass="CaptchaValue" ID="txtCode"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="txtCode"
                    ErrorMessage="Güvenlik Kodu alanı zorunlu" ValidationGroup="vgForm"
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td colspan="5" align="center">
                <div runat="server" id="divAlert">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <div style="width: 100%; background: #F3F6F7; font: normal 12px tahoma; color: #3F5968;
                    height: 100px; overflow: auto; border: 1px solid #666; padding: 8px; text-align:left">
                    <strong>Üyelik Avantajları</strong><br />
                    Banyom.com.tr e üye olarak sadece üyelere sunduğumuz avantajlardan anında yararlanmaya
                    başlayabilirsiniz. Düzenlenecek ortak kampanyalardan, promosyonlardan ilk siz haberdar
                    olur ve size özel avantajlardan yararlanabilirsiniz.<br />
                    Size özel kampanya ürünlerini incelemek ve faydalanabilmek için üye girişi yapmanız
                    yeterlidir. Bu bölümlerden sadece üyelerimiz yararlanabilmektedir.
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Button runat="server" ID="btnRegister" Text="Kayıt Ol" OnClick="btnRegister_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
