<%@ Page Title="" Language="C#" MasterPageFile="~/UIMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        İletişim Formu
    </h2>
    <p>
        <i>Bizimle iletişime geçin</i>
    </p>
    <table>
        <tr>
            <td>
                Ad Soyad
            </td>
            <td>
                :
            </td>
            <td>
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtName" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtName"
                    ErrorMessage="Ad Soyad alanı zorunlu" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Eposta
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
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtEmail"
                    ErrorMessage="Eposta alanı zorunlu" ValidationGroup="vgForm">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="regex1" ControlToValidate="txtEmail"
                    ErrorMessage="Geçersiz Eposta adresi" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                    ValidationGroup="ProfileForm" SetFocusOnError="true">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Başlık
            </td>
            <td>
                :
            </td>
            <td>
                *
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTitle" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtTitle"
                    ErrorMessage="Başlık alanı zorunlu" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top">
                Mesajınız
            </td>
            <td valign="top">
                :
            </td>
            <td valign="top">
                *
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtContent" Height="106px" Width="400px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtContent"
                    ErrorMessage="Lütfen Mesajınızı giriniz" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                <asp:Button runat="server" ID="btnSend" Text="Gönder" ValidationGroup="vgForm" OnClick="btnRegister_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
