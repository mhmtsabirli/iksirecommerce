<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="OrderAddress.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.OrderAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h3>
                Adres Bilgileri</h3>
            <h4>
                Siparişinizin teslim edileceği ve fatura edileceği adresleri seçiniz.
            </h4>
        </div>
        <table width="775px" cellpadding="0" cellspacing="0" style="padding-left: 40px;">
            <tr>
                <td valign="top" style="border-right: 1px solid #DEDEDE;" width="355px">
                    Teslimat Adresi
                </td>
                <td width="365px" style="padding-left: 10px;">
                    Fatura Adresi
                </td>
            </tr>
            <tr>
                <td valign="top" style="border-right: 1px solid #DEDEDE;" width="355px">
                    <asp:RadioButtonList runat="server" ID="rblShippingAddresses" OnSelectedIndexChanged="rblShippingAddresses_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>
                <td valign="top" width="365px" style="padding-left: 10px;">
                    <asp:RadioButtonList runat="server" ID="rblBillingAddresses" OnSelectedIndexChanged="rblBillingAddresses_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top" style="border-right: 1px solid #DEDEDE;" width="355px">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                &nbsp;<asp:LinkButton runat="server" ID="lbtnUpdateShippingAddress" Text="Seçili teslimat adresi bilgilerimi güncelle"
                                    OnClick="lbtnUpdateShippingAddress_Click"></asp:LinkButton>
                            </td>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lbtnNewShippingAddress" Text="Yeni" OnClick="lbtnNewShippingAddress_Click"></asp:LinkButton>
                            &nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label runat="server" ID="lblShippingAddressAlert"></asp:Label>
                    <asp:Panel runat="server" ID="pnlShippingAddress" Visible="false">
                        <table width="350px">
                            <tr>
                                <td colspan="4">
                                    <strong>
                                        <asp:Label runat="server" ID="lblShippingAddresFormTitle" Text="Adres Formu"></asp:Label></strong>
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressTitle"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtShippingAddressTitle"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="Adres Tanımı Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressFirstName"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtShippingAddressFirstName"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="İsim Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressLastName"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtShippingAddressLastName"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="Soyisim Girmelisiniz"
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
                                    <asp:DropDownList runat="server" ID="ddlShippingAddressCountries" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlShippingAddressCountries_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtShippingAddressCountryName" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorShippingAddressCountries" ControlToValidate="ddlShippingAddressCountries"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Ülke Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:DropDownList runat="server" ID="ddlShippingAddressCities" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlShippingAddressCities_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtShippingAddressCityName" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorShippingAddressCities" ControlToValidate="ddlShippingAddressCities"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Şehir Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:DropDownList runat="server" ID="ddlShippingAddressDistricts">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtShippingAddressDistrictName" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorShippingAddressDistricts" ControlToValidate="ddlShippingAddressDistricts"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="İlçe Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressPostCode"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtShippingAddressPostCode"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="Posta Kodu Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressLine" Width="250px" Height="50px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td valign="top">
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtShippingAddressLine"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="Adres Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressPhone"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="txtShippingAddressPhone"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="Telefon Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressGSMPhone"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:ValidationSummary runat="server" ID="vsForm" ValidationGroup="VGShippingAddressForm"
                                        ForeColor="Red" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Button runat="server" ID="btnShippingAddressSave" Text="Adres Bilgilerini Güncelle"
                                        ValidationGroup="VGShippingAddressForm" OnClick="btnShippingAddressSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td valign="top" width="365px" style="padding-left: 10px;">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                &nbsp;<asp:LinkButton runat="server" ID="lbtnUpdateBillingAddress" Text="Seçili fatura adresi bilgilerimi güncelle"
                                    OnClick="lbtnUpdateBillingAddress_Click"></asp:LinkButton>
                            </td>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lbtnNewBillingAddress" Text="Yeni" OnClick="lbtnNewBillingAddress_Click"></asp:LinkButton>
                                &nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <asp:Label runat="server" ID="lblBillingAddressAlert"></asp:Label>
                    <asp:Panel runat="server" ID="pnlBillingAddress" Visible="false">
                        <table width="350px">
                            <tr>
                                <td colspan="4">
                                    <strong>
                                        <asp:Label runat="server" ID="lblBillingAddressFormTitle" Text="Adres Formu"></asp:Label></strong>
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressTitle"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="txtBillingAddressTitle"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="Adres Tanımı Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressFirstName"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtBillingAddressFirstName"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="İsim Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressLastName"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="txtBillingAddressLastName"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="Soyisim Girmelisiniz"
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
                                    <asp:DropDownList runat="server" ID="ddlBillingAddressCountries" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlBillingAddressCountries_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtBillingAddressCountryName" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator16" ControlToValidate="ddlBillingAddressCountries"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Ülke Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:DropDownList runat="server" ID="ddlBillingAddressCities" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlBillingAddressCities_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtBillingAddressCityName" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorBillingAddressCities" ControlToValidate="ddlBillingAddressCities"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Şehir Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:DropDownList runat="server" ID="ddlBillingAddressDistricts">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtBillingAddressDistrictName" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorBillingAddressDistricts" ControlToValidate="ddlBillingAddressDistricts"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="İlçe Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressPostCode"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator21" ControlToValidate="txtBillingAddressPostCode"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="Posta Kodu Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressLine" Width="250px" Height="50px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td valign="top">
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator22" ControlToValidate="txtBillingAddressLine"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="Adres Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressPhone"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator23" ControlToValidate="txtBillingAddressPhone"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="Telefon Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressGSMPhone"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="VGBillingAddressForm"
                                        ForeColor="Red" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: center">
                                    <asp:Button runat="server" ID="btnBillingAddressSave" Text="Adres Bilgilerini Güncelle"
                                        ValidationGroup="VGBillingAddressForm" OnClick="btnBillingAddressSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    &nbsp;<asp:ImageButton runat="server" ID="imgbtnContinue" ImageUrl="../images/sepet_end_devam.jpg"
                        AlternateText="Devam Et" OnClick="imgbtnContinue_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
