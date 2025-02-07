﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.MyAccount" %>

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
            <td>
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Web20" MultiPageID="RadMultiPage1"
                    SelectedIndex="1" Widdth="600px">
                    <Tabs>
                        <telerik:RadTab Text="Üye Bilgilerim" Selected="true" PageViewID="RadPageView1">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Adreslerim" PageViewID="RadPageView2">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Siparişlerim" PageViewID="RadPageView3">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Favori Ürünlerim" PageViewID="RadPageView4">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Şifre Değiştir" PageViewID="RadPageView5">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
                    <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
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
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="txtUserInfoFirstName"
                                        ErrorMessage="Ad alanı zorunlu" ValidationGroup="vgUserInfo" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="txtUserInfoLastName"
                                        ErrorMessage="Soyad alanı zorunlu" ValidationGroup="vgUserInfo" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                                    <asp:TextBox runat="server" ID="txtUserInfoEmail"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtUserInfoEmail"
                                        ErrorMessage="Eposta alanı zorunlu" ValidationGroup="vgUserInfo">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="regex1" ControlToValidate="txtUserInfoEmail"
                                        ErrorMessage="Geçersiz Eposta adresi" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                        ValidationGroup="vgUserInfo" SetFocusOnError="true">*</asp:RegularExpressionValidator>
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
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator17" ControlToValidate="ddlUserInfoBirthDateDay"
                                        InitialValue="-1" ErrorMessage="Doğum Tarihi gün alanı zorunlu" ValidationGroup="vgUserInfo"
                                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator18" ControlToValidate="ddlUserInfoBirthDateMonth"
                                        InitialValue="-1" ErrorMessage="Doğum Tarihi ay alanı zorunlu" ValidationGroup="vgUserInfo"
                                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator19" ControlToValidate="ddlUserInfoBirthDateYear"
                                        InitialValue="-1" ErrorMessage="Doğum Tarihi yıl alanı zorunlu" ValidationGroup="vgUserInfo"
                                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator20" ControlToValidate="txtUserInfoMobilePhone"
                                        ErrorMessage="Cep Telefonu alanı zorunlu" ValidationGroup="vgUserInfo" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator21" ControlToValidate="txtUserInfoTCIdentity"
                                        ErrorMessage="TC Kimlik Numarası alanı zorunlu" ValidationGroup="vgUserInfo"
                                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
                                    <asp:Label runat="server" ID="lblUserInfoAlert"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="vgUserInfo"
                                        ForeColor="Red" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Button runat="server" ID="btnUserInfoSave" Text="Kaydet" ValidationGroup="vgUserInfo"
                                        OnClick="btnUserInfoSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView2" runat="server" Selected="true">
                        <table>
                            <tr>
                                <td>
                                    <strong>Adreslerim</strong> (Fatura ve teslimat adreslerinizi yönetin)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table id="tblMngForm">
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
                                                <div id="divAlert" runat="server">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" colspan="2">
                                                <asp:LinkButton runat="server" ID="lbtnNew" Text="Yeni Kayıt" OnClick="lbtnNew_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Panel runat="server" ID="pnlForm" Visible="false" CssClass="pnlForm">
                                                    <table>
                                                        <tr>
                                                            <td colspan="4">
                                                                <strong>Adres Formu</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Adres Tanımı
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtAddressTitle"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtAddressTitle"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Adres Tanımı Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Adres Tipi
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList runat="server" ID="ddlAddressType">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="ddlAddressType"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Adres Tanımı Seçiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                İsim
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtFirstName"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="İsim Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Soyisim
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtLastName"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Soyisim Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Ülke
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList runat="server" ID="ddlCountries" AutoPostBack="true" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlCountries"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Ülke Seçmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Şehir
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList runat="server" ID="ddlCities" AutoPostBack="true" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:TextBox runat="server" ID="txtCity" Visible="false"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="ddlCities"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Şehir Seçmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtCity"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Şehir Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                İlçe
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList runat="server" ID="ddlDistricts">
                                                                </asp:DropDownList>
                                                                <asp:TextBox runat="server" ID="txtDistrict" Visible="false"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="ddlDistricts"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="İlçe Seçmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtDistrict"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="İlçe Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Posta Kodu
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtPostCode"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtPostCode"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Posta Kodu Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                Adres
                                                            </td>
                                                            <td valign="top">
                                                                :
                                                            </td>
                                                            <td valign="top">
                                                                <asp:TextBox runat="server" ID="txtAddress" Width="250px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtAddress"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Adres Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Telefon
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="txtPhone"
                                                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Telefon Girmelisiniz"
                                                                    ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                                                <asp:TextBox runat="server" ID="txtGSMPhone"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="text-align: center">
                                                                <asp:ValidationSummary runat="server" ID="vsForm" ValidationGroup="VGForm" ForeColor="Red" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="text-align: center">
                                                                <asp:Button runat="server" ID="btnSave" Text="Kaydet" ValidationGroup="VGForm" OnClick="btnSave_Click" />
                                                                &nbsp;<asp:Button runat="server" ID="btnCancel" Text="Vazgeç" OnClick="btnCancel_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <br />
                                                <asp:Panel runat="server" ID="pnlList" Visible="true">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <strong>Adres Listesi</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" CellPadding="4"
                                                                    GridLines="None" PageSize="15" EnableModelValidation="True" Width="500px" EmptyDataText="Listede gösterilecek kayıt bulunamadı"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <Columns>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                                                    OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Adres Tipi">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="lblAddressType" Text='<%# Eval("Type.Value")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Title" HeaderText="Addres Tanımı" ApplyFormatInEditMode="false"
                                                                            ReadOnly="true" SortExpression="Title" />
                                                                        <asp:BoundField DataField="FirstName" HeaderText="İsim" ApplyFormatInEditMode="false"
                                                                            ReadOnly="true" SortExpression="FirstName" />
                                                                        <asp:BoundField DataField="LastName" HeaderText="Soyisim" ApplyFormatInEditMode="false"
                                                                            ReadOnly="true" SortExpression="LastName" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView3" runat="server" Selected="true">
                        <table>
                            <tr>
                                <td>
                                    <strong>Sipariş</strong> (Geçmiş ve aktif siparişlerinizi listeleyin)
                                </td>
                            </tr>
                        </table>
                        <div id="dvMyOrder" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td>
                                        Sipariş No
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblId"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ödeme Tipi
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPaymentType">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        Sipariş Toplam Fiyatı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:Label runat="server" ID="lbltotalPrice"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        Sipariş Vadeli Fiyat
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td colspan="2">
                                        <asp:Label runat="server" ID="lbltotalRatedPrice"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fatura Adres Detayı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBillingDetail"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        İl
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBillingCity"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        İlçe
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBillingDistrict"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Posta Kodu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBillingPostalCode"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div id="dvAdress" runat="server" visible="false">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Adres Detayı
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblDetail"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        İl
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCity"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        İlçe
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblDistrict"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Posta Kodu
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblPostalCode"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView runat="server" ID="gvBasketItems" AutoGenerateColumns="False" CellPadding="4"
                                            GridLines="None" PageSize="15" EnableModelValidation="True" Caption="Ürünler"
                                            CaptionAlign="Left">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnAddress" runat="server" OnClick="lbtnAddress_Click" CommandArgument='<%# Eval("Id")%>'>[Adres Bilgisi]</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ürün Adı">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Product.Title")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ürün Kodu">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblProductCode" Text='<%# Eval("Product.ProductCode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fiyat">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblPrice" Text='<%# Eval("ProductPrice.Price")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mikarı">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblCount" Text='<%# Eval("Count")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        Sipariş Durumu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlFilterOrderStatus">
                                            <asp:ListItem Text="Bekleyen Siparişler" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Tamamlanan Siparişler" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="İptal olan Siparişler" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td >
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sipariş Numarası
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOrderNo"></asp:TextBox>
                                    </td>
                                    <td >
                                    </td>
                                </tr>
                                <tr>
                                <td colspan="4">
                                    <asp:Button runat="server" ID="btnFilter" Text="Filtrele" OnClick="btnFilter_Click" />
                                </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <strong>Liste</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView runat="server" ID="gvOrderList" AutoGenerateColumns="False" CellPadding="4"
                                            GridLines="None" PageSize="15" EnableModelValidation="True" EmptyDataText="Listede gösterilecek kayıt bulunamadı">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnView" runat="server" OnClick="lbtnView_Click" CommandArgument='<%# Eval("Id")%>'>[Incele]</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                                    SortExpression="Id" />
                                                <asp:TemplateField HeaderText="Adı">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblGvFirstName" Text='<%# Eval("User.FirstName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Soyadı">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblGvLastName" Text='<%# Eval("User.LastName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ödeme Tipi">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblPaymentType" Text='<%# Eval("PaymetInfo.PaymentType.Value")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Durumu">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("Status.Value")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView4" runat="server" Selected="true">
                        <table>
                            <tr>
                                <td>
                                    <strong>Favori Ürünlerim</strong> (Favorilerinize eklediğiniz ürünler)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblNoUserFavoriteProducts" Text="Henüz hiç favori ürün eklememişsiniz."></asp:Label>
                                    <table>
                                        <asp:Repeater runat="server" ID="rptUserFavoriteProducts">
                                            <ItemTemplate>
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Product.Id")%>' />
                                                        <a href='<%# String.Format("ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                                            target="_blank">
                                                            <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "http://banyom.com.tr/documents/Images/Small/small_{0:C}")%>'
                                                                BorderWidth="0  " />
                                                        </a>
                                                    </td>
                                                    <td valign="top">
                                                        <h2>
                                                            <a href='<%# String.Format("../Pages/ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                                                target="_blank">
                                                                <%# Eval("Product.ProductCategory.Title")%>
                                                                /
                                                                <%# Eval("Product.Title")%>
                                                            </a>
                                                        </h2>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView5" runat="server" Selected="true">
                        <table>
                            <tr>
                                <td colspan="5">
                                    <strong>Şifre Değiştir</strong> (Şifrenizi değiştirin)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Yeni Şifre
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    *
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtChangePassword_Password" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="txtChangePassword_Password"
                                        ErrorMessage="Şifre alanı zorunlu" ValidationGroup="vgChangePassword" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Yeni Şifre tekrar
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    *
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtChangePassword_PasswordAgain" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator16" ControlToValidate="txtChangePassword_PasswordAgain"
                                        ErrorMessage="Şifre tekrar alanı zorunlu" ValidationGroup="vgChangePassword"
                                        SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <asp:CompareValidator runat="server" ID="cpValidator1" ValidationGroup="vgChangePassword"
                                        ControlToCompare="txtChangePassword_Password" ControlToValidate="txtChangePassword_PasswordAgain"
                                        ErrorMessage="Şifre ve Şifre tekrar alanları aynı olmalı">*
                                    </asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Label runat="server" ID="lblChangePassword_Alert"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:ValidationSummary runat="server" ID="ValidationSummary2" ValidationGroup="vgChangePassword"
                                        ForeColor="Red" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="center">
                                    <asp:Button runat="server" ID="btnChangePassword" Text="Şifremi Değiştir" ValidationGroup="vgChangePassword"
                                        OnClick="btnChangePassword_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
