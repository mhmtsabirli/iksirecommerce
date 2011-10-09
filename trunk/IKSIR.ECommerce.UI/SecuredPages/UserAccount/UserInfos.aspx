<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="UserInfos.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.UserAccount.UserInfos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Hesabım
    </h2>
    <p>
        Kullanıcı hesap biglileri görüntüleme, düzenleme.
    </p>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td align="left">
                <div id="divAlert" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="tabs">
                    <ul>
                        <li><a href="UserInfos.aspx" style="background-position: 0% -42px;"><span style="background-position: 0% -42px;">
                            Üye Bilgilerim</span></a></li>
                        <li><a href="Addresses.aspx"><span>Adreslerim</span></a></li>
                        <li><a href="Orders.aspx"><span>Siparişlerim</span></a></li>
                        <li><a href="FavoriteProducts.aspx"><span>Favori Ürünlerim</span></a></li>
                        <li><a href="ChangePassword.aspx"><span>Şifre Değiştir</span></a></li>
                    </ul>
                </div>
                <table>
                    <tr>
                        <td colspan="5">
                            <strong>Üye Bilgilerim</strong> (Hesabınız ile ilgili genel bilgiler)
                        </td>
                    </tr>
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
                            <asp:TextBox runat="server" ID="txtUserInfoFirstName"></asp:TextBox>
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
                            <asp:TextBox runat="server" ID="txtUserInfoLastName"></asp:TextBox>
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
                            <asp:TextBox runat="server" ID="txtUserInfoEmail"></asp:TextBox>
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
                            <asp:DropDownList runat="server" ID="ddlUserInfoBirthDateDay">
                            </asp:DropDownList>
                            /
                            <asp:DropDownList runat="server" ID="ddlUserInfoBirthDateMonth">
                            </asp:DropDownList>
                            /
                            <asp:DropDownList runat="server" ID="ddlUserInfoBirthDateYear">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cep Telefonu
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            *
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtUserInfoMobilePhone" MaxLength="11"></asp:TextBox>
                            <i>11 karakter</i>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            TC Kimlik Numarası
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            *
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtUserInfoTCIdentity" MaxLength="11"></asp:TextBox>
                            <i>11 karakter</i>
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
                    ErrorMessage="Güvenlik Kodu alanı zorunlu" 
                    SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </td>
        </tr>--%>
                    <tr>
                        <td colspan="5" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Button runat="server" ID="btnUserInfoSave" Text="Kaydet" OnClick="btnUserInfoSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
