<%@ Page Title="" Language="C#" MasterPageFile="~/UIMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Register" UICulture="tr" %>

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
                <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtFirstName"
                    ErrorMessage="Ad alanı zorunlu" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtLastName"
                    ErrorMessage="Soyad alanı zorunlu" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
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
                Şifre
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
                <asp:TextBox runat="server" ID="txtPasswordAgain" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtPasswordAgain"
                    ErrorMessage="Şifre tekrar alanı zorunlu" ValidationGroup="vgForm" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ID="cpValidator1" ValidationGroup="vgForm" ControlToCompare="txtPassword"
                    ControlToValidate="txtPasswordAgain" ErrorMessage="Şifre ve Şifre tekrar alanları aynı olmalı">*
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                Cinsiyet
            </td>
            <td>
                :
            </td>
            <td>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlGender">
                    <asp:ListItem Text="Seçiniz" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Bayan" Value="Bayan"></asp:ListItem>
                    <asp:ListItem Text="Bay" Value="Bay"></asp:ListItem>
                </asp:DropDownList>
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
                <asp:DropDownList runat="server" ID="ddlBirthDateDay">
                </asp:DropDownList>
                /
                <asp:DropDownList runat="server" ID="ddlBirthDateMount">
                </asp:DropDownList>
                /
                <asp:DropDownList runat="server" ID="ddlBirthDateYear">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="ddlBirthDateDay"
                    InitialValue="-1" ErrorMessage="Doğum Tarihi gün alanı zorunlu" ValidationGroup="vgForm"
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="ddlBirthDateMount"
                    InitialValue="-1" ErrorMessage="Doğum Tarihi ay alanı zorunlu" ValidationGroup="vgForm"
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlBirthDateYear"
                    InitialValue="-1" ErrorMessage="Doğum Tarihi yıl alanı zorunlu" ValidationGroup="vgForm"
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                <asp:Button runat="server" ID="btnRegister" Text="Kayıt Ol" ValidationGroup="vgForm"
                    OnClick="btnRegister_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
