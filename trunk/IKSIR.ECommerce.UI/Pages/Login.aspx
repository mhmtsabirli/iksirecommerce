<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Üye Girişi
    </h2>
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
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtName"
                    ErrorMessage="Ad Soyad alanı zorunlu" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtPassword"
                    ErrorMessage="Şifre alanı zorunlu" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label runat="server" ID="lblAlert"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:ValidationSummary runat="server" ID="vsForm" ValidationGroup="vgForm" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Button runat="server" ID="btnLogin" Text="Giriş" ValidationGroup="vgForm" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
