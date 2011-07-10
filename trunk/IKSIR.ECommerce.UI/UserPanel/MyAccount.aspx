<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIMasterPage.Master"
    AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="IKSIR.ECommerce.UI.UserPanel.MyAccount" %>

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
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Web20" MultiPageID="RadMultiPage1"
        SelectedIndex="1" Width="600px">
        <Tabs>
            <telerik:RadTab Text="Üye Bilgilerim" Selected="true" PageViewID="RadPageView1">
            </telerik:RadTab>
            <telerik:RadTab Text="Adreslerim" PageViewID="RadPageView2">
            </telerik:RadTab>
            <telerik:RadTab Text="Siparişlerim" PageViewID="RadPageView3">
            </telerik:RadTab>
            <telerik:RadTab Text="Şifre Değiştir" PageViewID="RadPageView4">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
            <table>
                <tr>
                    <td colspan="4">
                        <strong>Üye Bilgilerim</strong> (Hesabınız ile ilgili genel bilgiler)
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" Selected="true">
            <table>
                <tr>
                    <td colspan="4">
                        <strong>Adreslerim</strong> (Fatura ve teslimat adreslerinizi yönetin)
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
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
                                                    Adres Tanımı
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
                                                    <asp:TextBox runat="server" ID="txtAddress" Width="250px" Height="50px"></asp:TextBox>
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
                                                        GridLines="None" PageSize="15" EnableModelValidation="True" Width="500px" EmptyDataText="Listede gösterilecek kayıt bulunamadı" HeaderStyle-HorizontalAlign="Left">
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
                    <td colspan="4">
                        <strong>Sipariş</strong> (Geçmiş ve aktif siparişlerinizi listeleyin)
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView4" runat="server" Selected="true">
            <table>
                <tr>
                    <td colspan="4">
                        <strong>Şifre Değiştir</strong> (Şifrenizi değiştirin)
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>
