<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" ValidateRequest="false" CodeBehind="ProductPrices.aspx.cs"
    Inherits="IKSIR.ECommerce.Management.ProductManagement.ProductPrices" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Ürün Fiyat Tanımlama
    </h2>
    <p>
        Ürün Fiyat Kargo bilgileri güncelleme ve tanımlama ekranı
    </p>
    <table id="tblMngForm">
        <tr>
            <td colspan="2">
                Blgi:<br />
                <div id="divAlert" runat="server" class="scrolledDiv">
                </div>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:LinkButton runat="server" ID="lbtnNew" Text="Yeni Kayıt" OnClick="lbtnNew_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Panel runat="server" ID="pnlForm" Visible="false" CssClass="pnlForm">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Web20" MultiPageID="RadMultiPage1"
                        SelectedIndex="1" Width="400px">
                        <Tabs>
                            <telerik:RadTab Text="Ürün Fiyat" Selected="true" PageViewID="RadPageView1">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Kargo Fiyat" PageViewID="RadPageView2">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ürün Fiyat Formu</strong> (Ürünlerin Fiyat Bilgileri)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Id
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblProductPriceId" Text="Yeni Kayıt"></asp:Label>
                                        <asp:Label runat="server" ID="lblProductId" Visible="false" Text=""></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ürün Kodu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="100%" ID="txtProductCode"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnSearch" Text="Ürün Bul" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ürün Adı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="100%" Enabled="false" ID="txtProductName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv23" ControlToValidate="txtProductName"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Ürün Bulunuz" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kdv Oranı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtTax"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtTax"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Kdv Oranı Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTax"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Birim Fiyat
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtUnitPriceOne"></asp:TextBox>
                                                </td>
                                                <td>
                                                    ,
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtUnitPriceTwo"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnCal" Text="Hesapla" OnClick="btnCal_Click" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtUnitPriceOne"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtUnitPriceTwo"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUnitPriceOne"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUnitPriceTwo"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kdv'li Fiyat
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox runat="server" Enabled="false" ID="txtPriceOne"></asp:TextBox>
                                                </td>
                                                <td>
                                                    ,
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" Enabled="false" ID="txtPriceTwo"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtPriceOne"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtPriceTwo"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ürün Kargo Bilgisi</strong> (Ürünlerin Kargo Bilgilerini tanımlama
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Id
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblProductShipmentPriceId" Text="Yeni Kayıt"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kargo Firması
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlShipment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShipment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="ddlShipment"
                                            ValidationGroup="vgProductProperties" SetFocusOnError="true" InitialValue="-1"
                                            ErrorMessage="Özellik seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Baz Değer Kullanılsın
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chBaz" Enabled="false" runat="server" AutoPostBack="true" OnCheckedChanged="chBaz_CheckedChanged" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div id="divUnit" visible="false" runat="server">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Değer
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" Enabled="false" ID="txtShUnitPrice"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ağırlık/ Desi
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtDesi"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDesi"
                                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnShCall" Text="Hesapla" OnClick="btnShCall_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kargo Değeri
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtShpriceOne"></asp:TextBox>
                                                </td>
                                                <td>
                                                    ,
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtShpriceTwo"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtShpriceOne"
                                            ValidationGroup="vgProductProperties" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="txtShpriceTwo"
                                            ValidationGroup="vgProductProperties" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtShpriceOne"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtShpriceTwo"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Label ID="lblPropertyAlert" runat="server" Visible="false"></asp:Label>
                                        <asp:ValidationSummary runat="server" ID="vsProductProperties" ValidationGroup="vgProductProperties"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Button ID="btnAddShipmentPrice" runat="server" Text="Kargo Kaydet" ValidationGroup="vgProductProperties"
                                            OnClick="btnAddShipmentPrice_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView runat="server" ID="gvProductShipment" AutoGenerateColumns="False" CellPadding="4"
                                GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" Caption="Ürün Kargo Bilgieri"
                                CaptionAlign="Left">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtShipmentEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnShipmentyDelete_Click"
                                                CommandArgument='<%# Eval("Id")%>' OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                        SortExpression="Id" />
                                    <asp:TemplateField HeaderText="Kargo">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Shipment.Title")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Price" HeaderText="Fiyat" ApplyFormatInEditMode="false"
                                        ReadOnly="true" SortExpression="Price" />
                                </Columns>
                            </asp:GridView>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    <table>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="VGForm" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Kaydet" ValidationGroup="VGForm" />&#160;<asp:Button
                                    ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Vazgeç" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlFilter" Visible="true">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Filtre</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ürün Kodu
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFilterProductCode"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filtrele" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel runat="server" ID="pnlList" Visible="true">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Liste</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" CellPadding="4"
                                    Font-Size="Small" EmptyDataText="Listede gösterilecek kayıt bulunamadı" GridLines="None"
                                    PageSize="10" EnableModelValidation="True" Width="100%" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                    OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:TemplateField HeaderText="Ürün">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblProductName" Text='<%# Eval("Product.Title")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="UnitPrice" HeaderText="Baz Fiyat" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="UnitPrice" />
                                        <asp:BoundField DataField="Tax" HeaderText="Vergi Oranı" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Tax" />
                                        <asp:BoundField DataField="Price" HeaderText="Vergili Fiyat" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Price" />
                                        <asp:TemplateField HeaderText="Value" Visible="false">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
