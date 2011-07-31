<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Üye Girişi</h2>
    <p>
        <i>Lütfen üye girişi yapınız</i>
    </p>
    <table>
        <tr>
            <td>
                Kullanıcı adı (Epostanız)
            </td>
            <td>
                :
            </td>
            <td>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtEmail"
                    SetFocusOnError="true" ErrorMessage="Kullanıcı adınızı girmelisiniz" ValidationGroup="vgLoginForm">*</asp:RequiredFieldValidator>
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
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPassword"
                    SetFocusOnError="true" ErrorMessage="Şifrenizi girmelisiniz" ValidationGroup="vgLoginForm">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label runat="server" ID="lblAlert"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:ValidationSummary runat="server" ID="vsLoginForm" ValidationGroup="vgLoginForm" />
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Button runat="server" ID="btnLogin" Text="Giriş" OnClick="btnLogin_Click" ValidationGroup="vgLoginForm" />
            </td>
        </tr>
    </table>
</asp:Content>
