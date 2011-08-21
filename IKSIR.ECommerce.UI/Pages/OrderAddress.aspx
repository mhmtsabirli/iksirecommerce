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
                <td width="365px" style="padding-left:10px;">
                    Fatura Adresi
                </td>
            </tr>
            <tr>
                <td valign="top" style="border-right: 1px solid #DEDEDE;" width="355px">
                    <asp:RadioButtonList runat="server" ID="rblShippingAddresses" 
                        OnSelectedIndexChanged="rblShippingAddresses_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>
                <td valign="top" width="365px" style="padding-left:10px;">
                    <asp:RadioButtonList runat="server" ID="rblBillingAddresses"
                        OnSelectedIndexChanged="rblBillingAddresses_SelectedIndexChanged">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top" style="border-right: 1px solid #DEDEDE;" width="355px">
                    <a href="#" id="anchorShippingAddress">Seçili adres bilgilerimi güncelle</a>
                    <script type="text/javascript">
                        $("#anchorShippingAddress").click(function () {
                            if ($(".divShippingAddress").is(':visible'))
                                $(".divShippingAddress").slideUp('slow');
                            else
                                $(".divShippingAddress").slideDown('slow');
                        });
                    </script>
                    <br />
                    <div class="divShippingAddress" style="display: none;">
                        <table width="350px">
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
                                    Adres Tanımı
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlShippingAddressType">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="ddlShippingAddressType"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Adres Tanımı Seçiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlShippingAddressCountries"
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
                                    <asp:TextBox runat="server" ID="txtCity" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="ddlShippingAddressCities"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Şehir Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtCity"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="Şehir Girmelisiniz"
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
                                    <asp:DropDownList runat="server" ID="ddlShippingAddressDistricts">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtDistrict" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="ddlShippingAddressDistricts"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="İlçe Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtDistrict"
                                        ValidationGroup="VGShippingAddressForm" SetFocusOnError="true" ErrorMessage="İlçe Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtShippingAddressLine" Width="250px" Height="50px"></asp:TextBox>
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
                    </div>
                </td>
                <td valign="top" width="365px" style="padding-left:10px;">
                    <a href="#" id="anchorBillingAddress">Seçili adres bilgilerimi güncelle</a>
                    <script type="text/javascript">
                        $("#anchorBillingAddress").click(function () {
                            if ($(".divBillingAddress").is(':visible'))
                                $(".divBillingAddress").slideUp('slow');
                            else
                                $(".divBillingAddress").slideDown('slow');
                        });
                    </script>
                    <br />
                    <div class="divBillingAddress" style="display: none;">
                        <table width="350px">
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
                                    Adres Tanımı
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlBillingAddressType">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ddlBillingAddressType"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Adres Tanımı Seçiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                    <asp:TextBox runat="server" ID="TextBox4" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator17" ControlToValidate="ddlBillingAddressCities"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="Şehir Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator18" ControlToValidate="txtCity"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="Şehir Girmelisiniz"
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
                                    <asp:DropDownList runat="server" ID="ddlBillingAddressDistricts">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="TextBox5" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator19" ControlToValidate="ddlBillingAddressDistricts"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" InitialValue="-1"
                                        ErrorMessage="İlçe Seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator20" ControlToValidate="txtDistrict"
                                        ValidationGroup="VGBillingAddressForm" SetFocusOnError="true" ErrorMessage="İlçe Girmelisiniz"
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
                                    <asp:TextBox runat="server" ID="txtBillingAddressLine" Width="250px" Height="50px"></asp:TextBox>
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
                                    <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="txtBillingAddressPhone"
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
                    </div>
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
